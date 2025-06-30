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
                    this.menuButtonsChecklist.Items.Add(button.Text, button.Visible);
                }
            }
            catch (Exception ex)
            {
                log.Error("Error in MakeButtonCheckboxes", ex);
                MessageBox.Show($"Error in MakeButtonCheckboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
