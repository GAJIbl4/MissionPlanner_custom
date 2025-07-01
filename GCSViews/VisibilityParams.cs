using log4net;
using MissionPlanner.Controls;
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
using MissionPlanner.Utilities;

namespace MissionPlanner.GCSViews
{
    public partial class VisibilityParams : MyUserControl, IActivate, IDeactivate
    {
        internal static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public VisibilityParams()

        {
            InitializeComponent();
            log.Info("Visibility params constructor called");
            this.makeButtonCheckboxes();
            this.makeContextMapCheckboxes();

        }

        public void Activate()
        {
            log.Info("Visibility params activated");      


        }

        public void Deactivate()
        {
            log.Info("Visibility params deactivated");
            // Add any deactivation logic here
        }

        public void makeButtonCheckboxes()
        {
            log.Info("Making button checkboxes");
            try
            {
                var mainForm = MainV2.instance;

                var menuButtons = mainForm.MainMenu.Items.OfType<ToolStripButton>().ToList();

                foreach (var button in menuButtons)
                {
                    if (button.Name == "MenuConnect" || button.Name == "MenuArduPilot")
                    {
                        continue; // Skip MenuConnect and ArduPilot
                    }
                    var checkboxItem = new MyCheckBoxItem(button.Name, button.Text, button.Visible);
                    this.menuButtonsChecklist.Items.Add(checkboxItem, checkboxItem.IsChecked);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in MakeButtonCheckboxes", ex);
                MessageBox.Show($"Error in MakeButtonCheckboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void makeContextMapCheckboxes()
        {
            try
            {
                var mainForm = MainV2.instance;
                var contextMapButtons = mainForm.FlightData.contextMenuStripMap.Items.OfType<ToolStripMenuItem>().ToList();
                var allowedList = new HashSet<string>(Settings.Instance.GetList("AllowedContextMenuMapItems"));

                foreach (var button in contextMapButtons)
                {
                    var isChecked = false;
                    if (allowedList.Contains(button.Name))
                    {
                        isChecked = true;
                    }
                    var checkboxItem = new MyCheckBoxItem(button.Name, button.Text, isChecked);
                    this.mapContextMenuChecklist.Items.Add(checkboxItem, checkboxItem.IsChecked);

                }
            }
            catch (Exception ex)
            {
                log.Error("Error in MakeContextMapCheckboxes", ex);
                MessageBox.Show($"Error in MakeContextMapCheckboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuButtonsChecklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var mainForm = MainV2.instance;

                var currentItem = menuButtonsChecklist.Items[e.Index] as MyCheckBoxItem;
                if (currentItem != null)
                {
                    // Обновляем свойство IsChecked в зависимости от нового состояния
                    currentItem.IsChecked = e.NewValue == CheckState.Checked;
                }

                foreach (MyCheckBoxItem item in menuButtonsChecklist.Items)
                {
                    try
                    {
                        var key = "MenuVisible_" + item.Name;

                        // Check if the setting exists, if not, set default value (True)
                        if (!Settings.Instance.ContainsKey(key))
                        {
                            log.Info($"Setting {key} not found. Adding default value: True");
                            Settings.Instance[key] = true.ToString();
                        }

                        log.Info($"Current {key} is {Settings.Instance.GetBoolean(key)}");
                        Settings.Instance[key] = item.IsChecked.ToString();
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Error updating settings for item {item.Name}", ex);
                        MessageBox.Show($"Error updating settings for item {item.Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Settings.Instance.Save();
                mainForm.ApplySavedMenuVisibility();
            }
            catch (Exception ex)
            {
                log.Error("Error in MenuButtonsChecklist_SelectedIndexChanged", ex);
                MessageBox.Show($"Error in MenuButtonsChecklist_SelectedIndexChanged: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateSettings()
        {

        }

        private HashSet<string> GetMapContextMenuChecklistValues()
        {
            var hashSet = new HashSet<string>();

            foreach (MyCheckBoxItem item in mapContextMenuChecklist.Items)
            {
                if (item.IsChecked)
                {
                    hashSet.Add(item.Name);
                }
            }

            return hashSet;
        }

        private void mapContextMenuChecklist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                var mainForm = MainV2.instance;
                var currentItem = mapContextMenuChecklist.Items[e.Index] as MyCheckBoxItem;
                if (currentItem != null)
                {
                    currentItem.IsChecked = e.NewValue == CheckState.Checked;
                }

                var allowedList = GetMapContextMenuChecklistValues();
                Settings.Instance.SetList("AllowedContextMenuMapItems", allowedList);
                mainForm.ApplySavedMenuVisibility();
            }
            catch (Exception ex)
            {
                log.Error("Error in MapContextMenuChecklist_ItemCheck", ex);
                MessageBox.Show($"Error in MapContextMenuChecklist_ItemCheck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class MyCheckBoxItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
        public MyCheckBoxItem(string name, string text, bool isChecked)
        {
            Name = name;
            Text = text;
            IsChecked = isChecked;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
