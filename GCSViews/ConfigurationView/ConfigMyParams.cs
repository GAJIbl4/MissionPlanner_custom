using log4net;
using Microsoft.Diagnostics.Runtime.ICorDebug;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class configMyParams : MyUserControl, IActivate, IDeactivate
    {
        // Включаем логи
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // Обозначаем, что таблица это rowlist
        internal static List<DataGridViewRow> rowlist = new List<DataGridViewRow>();
        // Максимальная длина строки для подсказки
        private const int maximumSingleLineTooltipLength = 50;
        // Префикс для параметров
        private const string parameterPrefix = "AHRS";
        // Флаг для проверки, что параметры уже загружены
        private bool startup = false;
        // Словарь для хранения изменений параметров
        private Dictionary<string, object> _changes = new Dictionary<string, object>();


        public configMyParams()
        {
            InitializeComponent();
            log.Info("configMyParams constructor called");
            processToScreen();
        }

        public void Activate()
        {
            // Logic to execute when activated
            log.Info("ConfigMyParams activated");
        }

        public void Deactivate()
        {
            // Logic to execute when deactivated
            log.Info("ConfigMyParams deactivated");
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            // sort with enable at the bottom - this ensures params are set before the function is disabled
            var temp = _changes.Keys.Cast<string>().ToList();

            temp.SortENABLE();

            bool enable = temp.Any(a => a.EndsWith("_ENABLE"));

            int error = 0;
            bool reboot = false;
            int maxdisplay = 20;

            if (temp.Count > 0 && temp.Count <= maxdisplay)
            {
                // List to track successfully saved parameters
                List<string> savedParams = new List<string>();

                foreach (string value in temp)
                {
                    if (MainV2.comPort.BaseStream == null || !MainV2.comPort.BaseStream.IsOpen)
                    {
                        CustomMessageBox.Show("You are not connected", Strings.ERROR);
                        return;
                    }

                    // Get the previous value of the param to display in 'param change info'
                    // (a better way would be to get the value somewhere from inside the code, insted of recieving it over mavlink)
                    string previousValue = MainV2.comPort.MAV.param[value].ToString();
                    // new value of param
                    double newValue = (double)_changes[value];

                    // Add the parameter, previous and new values to the list for 'param change info'
                    // remember, the 'value' here is key of param, while prev and new are actual values of param
                    savedParams.Add($"{value}: {previousValue} -> {newValue}");
                }

                // Join the saved parameters list to a string
                string savedParamsMessage = string.Join(Environment.NewLine, savedParams);

                // Ask the user for confirmation showing detailed changes
                if (CustomMessageBox.Show($"You are about to change {savedParams.Count} parameters. Please review the changes below:\n\n{savedParamsMessage}\n\nDo you want to proceed?", "Confirm Parameter Changes",
        CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information) !=
    CustomMessageBox.DialogResult.Yes)
                    return;
            }
            else if (temp.Count > maxdisplay)
            {
                // Ask the user for confirmation without listing individual changes
                if (CustomMessageBox.Show($"You are about to change {temp.Count} parameters. Are you sure you want to proceed?", "Confirm Parameter Changes",
            CustomMessageBox.MessageBoxButtons.YesNo, CustomMessageBox.MessageBoxIcon.Information) !=
        CustomMessageBox.DialogResult.Yes)
                    return;
            }


            foreach (string value in temp)
            {
                try
                {
                    if (MainV2.comPort.BaseStream == null || !MainV2.comPort.BaseStream.IsOpen)
                    {
                        CustomMessageBox.Show("Your are not connected", Strings.ERROR);
                        return;
                    }

                    MainV2.comPort.setParam(value, (double)_changes[value]);
                    //check if reboot required
                    if (ParameterMetaDataRepository.GetParameterRebootRequired(value, MainV2.comPort.MAV.cs.firmware.ToString()))
                    {
                        reboot = true;
                    }
                    try
                    {
                        // set control as well
                        var textControls = Controls.Find(value, true);
                        if (textControls.Length > 0)
                        {
                            ThemeManager.ApplyThemeTo(textControls[0]);
                        }
                    }
                    catch
                    {
                    }

                    try
                    {
                        // set param table as well
                        foreach (DataGridViewRow row in Params.Rows)
                        {
                            if (row.Cells[OptionName.Index].Value.ToString() == value)
                            {
                                row.Cells[Value.Index].Style.BackColor = ThemeManager.ControlBGColor;
                                _changes.Remove(value);
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                    error++;
                    CustomMessageBox.Show("Set " + value + " Failed");
                }
            }

            if (error > 0)
                CustomMessageBox.Show("Not all parameters successfully saved.", "Saved");
            else if (temp.Count > 0)
                CustomMessageBox.Show($"{temp.Count} parameters successfully saved.", "Saved");
            else
                CustomMessageBox.Show("No parameters were changed.", "No changes");

            //Check if reboot is required
            if (reboot)
            {
                CustomMessageBox.Show("Reboot is required for some parameters to take effect.", "Reboot Required");
            }

            if (MainV2.comPort.MAV.param.TotalReceived != MainV2.comPort.MAV.param.TotalReported)
            {
                if (MainV2.comPort.MAV.cs.armed)
                {
                    CustomMessageBox.Show("The number of available parameters changed, until full param refresh is done, some parameters will not be available.", "Params");
                    //Hack the number of reported params to keep params list available
                    MainV2.comPort.MAV.param.TotalReported = MainV2.comPort.MAV.param.TotalReceived;
                }
                else
                {
                    CustomMessageBox.Show("The number of available parameters changed. A full param refresh will be done to show all params.", "Params");
                    //Click on refresh button
                    refreshButton_Click(refreshButton, null);
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            log.Info("Refresh button clicked");
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            if (!MainV2.comPort.MAV.cs.armed || DialogResult.OK ==
                Common.MessageShowAgain("Refresh Params", Strings.WarningUpdateParamList, true))
            {
                ((Control)sender).Enabled = false;

                try
                {
                    MainV2.comPort.getParamList();
                }
                catch (Exception ex)
                {
                    log.Error("Exception getting param list", ex);
                    CustomMessageBox.Show(Strings.ErrorReceivingParams, Strings.ERROR);
                }


                ((Control)sender).Enabled = true;

                startup = true; // Set startup to true to reload parameters
                processToScreen();
                startup = false; // Reset startup to false after processing

            }

        }

        internal void processToScreen()
        {
            // toolTip1.RemoveAll();
            Params.Rows.Clear();
            log.Info("processToScreen");

            var list = new List<string>();

            // process hashdefines and update display
            // But only if startup is true, otherwise we assume that rowlist is valid and just put it back
            // to the gridview

            if (startup)
            {
                // Добавляем только те ключи, которые начинаются с префикса
                foreach (string item in MainV2.comPort.MAV.param.Keys)
                    if (item != null && item.StartsWith(parameterPrefix))
                        list.Add(item);

                rowlist.Clear();

                bool has_defaults = false;

                Parallel.ForEach(list, value =>
                {
                    if (value == null || value == "")
                        return;

                    var row = new DataGridViewRow() { Height = 36 };
                    lock (rowlist)
                        rowlist.Add(row);
                    row.CreateCells(Params);
                    row.Cells[OptionName.Index].Value = value;
                    row.Cells[Value.Index].Value = MainV2.comPort.MAV.param[value].ToString();

                    if (MainV2.comPort.MAV.param[value].default_value.HasValue)
                    {
                        has_defaults = true;
                        row.Cells[Default.Index].Value = MainV2.comPort.MAV.param[value].default_value_to_string();
                    }
                    else
                    {
                        row.Cells[Default.Index].Value = "NaN";
                    }
                    try
                    {
                        var metaDataDescription = ParameterMetaDataRepository.GetParameterMetaData(value,
                            ParameterMetaDataConstants.Description, MainV2.comPort.MAV.cs.firmware.ToString());
                        if (!string.IsNullOrEmpty(metaDataDescription))
                        {
                            row.Cells[OptionName.Index].ToolTipText = AddNewLinesForTooltip(metaDataDescription);
                            row.Cells[Value.Index].ToolTipText = AddNewLinesForTooltip(metaDataDescription);

                            var range = ParameterMetaDataRepository.GetParameterMetaData(value,
                                ParameterMetaDataConstants.Range, MainV2.comPort.MAV.cs.firmware.ToString());
                            var options = ParameterMetaDataRepository.GetParameterMetaData(value,
                                ParameterMetaDataConstants.Values, MainV2.comPort.MAV.cs.firmware.ToString());
                            var units = ParameterMetaDataRepository.GetParameterMetaData(value,
                                ParameterMetaDataConstants.Units, MainV2.comPort.MAV.cs.firmware.ToString());

                            row.Cells[Units.Index].Value = units;
                            row.Cells[Options.Index].Value = (range + "\n" + options.Replace(",", "\n")).Trim();
                            if (options.Length > 0) row.Cells[Options.Index].ToolTipText = options.Replace(',', '\n');
                            int N = options.Count(c => c.Equals(','));
                            if (N > 50)
                            {
                                int columns = (N - 1) / 50 + 1;
                                StringBuilder ans = new StringBuilder();
                                var opts = options.Split(',');
                                int i = 0;
                                while (true)
                                {
                                    for (int j = 0; j < columns; j++)
                                    {
                                        ans.Append(opts[i] + ", ");
                                        i++;
                                        if (i >= N) break;
                                    }
                                    if (i >= N) break;
                                    ans.Append("\n");
                                }
                                row.Cells[Options.Index].ToolTipText = ans.ToInvariantString();
                            }
                            row.Cells[Desc.Index].Value = metaDataDescription;
                            row.Cells[Desc.Index].ToolTipText = AddNewLinesForTooltip(metaDataDescription);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                });

                Default.Visible = has_defaults;
            }
            else
            {
                foreach (DataGridViewRow r in rowlist)
                {
                    r.Cells[Value.Index].Value = MainV2.comPort.MAV.param[r.Cells[OptionName.Index].Value.ToString()].ToString();
                }
            }



            Params.Visible = false;

            Params.Rows.AddRange(rowlist.ToArray());

            // log.Info("about to sort");

            // Params.SortCompare += OnParamsOnSortCompare;

            // Params.Sort(Params.Columns[Command.Index], ListSortDirection.Ascending);

            Params.Visible = true;

            //if (splitContainer1.Panel1Collapsed == false)
            //{
            //    BuildTree();
            //}

            log.Info("Done");
        }
        private static string AddNewLinesForTooltip(string text)
        {
            if (text.Length < maximumSingleLineTooltipLength)
                return text;
            var lineLength = (int)Math.Sqrt(text.Length) * 2;
            var sb = new StringBuilder();
            var currentLinePosition = 0;
            for (var textIndex = 0; textIndex < text.Length; textIndex++)
            {
                // If we have reached the target line length and the next
                // character is whitespace then begin a new line.
                if (currentLinePosition >= lineLength &&
                    char.IsWhiteSpace(text[textIndex]))
                {
                    sb.Append(Environment.NewLine);
                    currentLinePosition = 0;
                }
                // If we have just started a new line, skip all the whitespace.
                if (currentLinePosition == 0)
                    while (textIndex < text.Length && char.IsWhiteSpace(text[textIndex]))
                        textIndex++;
                // Append the next character.
                if (textIndex < text.Length) sb.Append(text[textIndex]);
                currentLinePosition++;
            }
            return sb.ToString();
        }

        private void compareButton_Click(object sender, EventArgs e)
        {

        }
    }
}
