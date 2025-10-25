using log4net;
using MissionPlanner.Controls;
using MissionPlanner.Utilities;
using RTSPPlayer;
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

namespace MissionPlanner.GCSViews
{
    public partial class RTSPSettings : MyUserControl, IActivate, IDeactivate
    {

        internal static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public RTSPSettings()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            log.Info("RTSP Settings activated");

            try
            {
                this.loadSettings();
                DecoderSettings settings = new DecoderSettings();
                DecoderSettingsUIBuilder.BuildDecoderSettingsUI(settings, this.DecoderSettingsTable);
            }
            catch (Exception ex) 
            {
                log.Error($"RSTP Activate error: {ex.Message}");
            }
        }
        public void Deactivate()
        {
            log.Info("RTSP Settings deactivated");
            try
            {
                if (this.checkBox1.Checked)
                {
                    this.saveSettings();
                }
            }
            catch (Exception ex)
            {
                log.Error($"RTSP Settings deactivate error: {ex.Message}");
            }
            
        }

        private void loadSettings()
        {
            try
            {
                if (!Settings.Instance.ContainsKey("RTSP_IP"))
                {
                    log.Info("RTSP Settings not found, creating default one");
                    Settings.Instance["RTSP_IP"] = "37.39.126.110";
                    Settings.Instance["RTSP_Port"] = "554";
                    Settings.Instance["RTSP_Login"] = "admin";
                    Settings.Instance["RTSP_Password"] = "admin";
                    Settings.Instance.Save();
                }

                this.IPTextBox.Text = Settings.Instance["RTSP_IP"];
                this.textBox1.Text = Settings.Instance["RTSP_Port"];
                this.textBox2.Text = Settings.Instance["RTSP_Login"];
                this.textBox3.Text = Settings.Instance["RTSP_Password"]; 
            }
            catch (Exception ex) 
            {
                log.Error("RTSP Settings Error: ", ex);
            }
        }

        private void saveSettings()
        {
            try
            {
                if (this.checkBox1.Checked)
                {
                    log.Info("RTSP Settings not found, creating default one");
                    Settings.Instance["RTSP_IP"] = this.IPTextBox.Text;
                    Settings.Instance["RTSP_Port"] = this.textBox1.Text;
                    Settings.Instance["RTSP_Login"] = this.textBox2.Text;
                    Settings.Instance["RTSP_Password"] = this.textBox3.Text;
                    Settings.Instance.Save();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            try 
            {  
                string rtspUrl = $"rtsp://{this.textBox2.Text}:{this.textBox3.Text}@{this.IPTextBox.Text}:{this.textBox1.Text}/Streaming/channels/1";
                this.rtspPlayerControl1.Play(rtspUrl);
                if (this.checkBox1.Checked)
                { 
                    log.Info("Saving RTSP Settings");
                    this.saveSettings();
                } 
            }
            catch (Exception ex)
            {
                log.Error($"RTSP Play ERROR: {ex.Message}");
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.rtspPlayerControl1.Stop();
            }
            catch (Exception ex)
            {
                log.Error($"RTSP Stop ERROR: {ex.Message}");
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int planeNumber = Decimal.ToInt32(this.planeNumberEdit.Value);
                if (planeNumber >= 10000 && planeNumber <= 99999)
                {
                    this.IPTextBox.Text = $"39.37.{planeNumber-9984}.110";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }

    public static class DecoderSettingsUIBuilder
    {
        /// <summary>
        /// Создаёт элементы UI для всех свойств DecoderSettings,
        /// основываясь на атрибутах SettingInfoAttribute.
        /// </summary>
        public static void BuildDecoderSettingsUI(DecoderSettings settings, TableLayoutPanel layout)
        {
            layout.SuspendLayout();
            layout.Controls.Clear();
            layout.RowStyles.Clear();

            layout.ColumnCount = 2;
            layout.ColumnStyles.Clear();
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            layout.AutoSize = true;
            layout.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            var props = typeof(DecoderSettings)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<SettingInfoAttribute>() != null)
                .ToArray();

            int row = 0;
            var tooltip = new ToolTip();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<SettingInfoAttribute>();
                layout.RowCount++;
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Метка слева
                var label = new Label
                {
                    Text = attr.DisplayName + (string.IsNullOrEmpty(attr.Unit) ? "" : $" ({attr.Unit})"),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    Margin = new Padding(3, 3, 3, 3)
                };
                tooltip.SetToolTip(label, attr.Description);
                layout.Controls.Add(label, 0, row);

                // Контрол справа
                Control control;

                if (prop.PropertyType == typeof(bool))
                {
                    var chk = new CheckBox
                    {
                        Checked = (bool)prop.GetValue(settings),
                        Dock = DockStyle.Left,
                        AutoSize = true
                    };
                    chk.CheckedChanged += (_, __) => prop.SetValue(settings, chk.Checked);
                    tooltip.SetToolTip(chk, attr.Description);
                    control = chk;
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(double))
                {
                    var num = new NumericUpDown
                    {
                        Minimum = (decimal)attr.Min,
                        Maximum = (decimal)(attr.Max > 0 ? attr.Max : 1000000),
                        Increment = (decimal)Math.Max(attr.Step, 1),
                        DecimalPlaces = prop.PropertyType == typeof(double) ? 2 : 0,
                        Value = Convert.ToDecimal(prop.GetValue(settings)),
                        Dock = DockStyle.Fill
                    };
                    num.ValueChanged += (_, __) =>
                    {
                        if (prop.PropertyType == typeof(int))
                            prop.SetValue(settings, (int)num.Value);
                        else
                            prop.SetValue(settings, (double)num.Value);
                    };
                    tooltip.SetToolTip(num, attr.Description);
                    control = num;
                }
                else
                {
                    var txt = new TextBox
                    {
                        Text = prop.GetValue(settings)?.ToString() ?? "",
                        Dock = DockStyle.Fill
                    };
                    txt.TextChanged += (_, __) => prop.SetValue(settings, txt.Text);
                    tooltip.SetToolTip(txt, attr.Description);
                    control = txt;
                }

                layout.Controls.Add(control, 1, row);
                row++;
            }

            layout.ResumeLayout();
        }
    }
}
