﻿using MissionPlanner.Controls;
using MissionPlanner.Properties;
using MissionPlanner.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class Wind : MyUserControl, IActivate
    {
        public Wind()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            try
            {
                CHK_showconsole.Checked = Settings.Instance.GetBoolean("showconsole");
            }
            catch
            {
            }

            if (Program.WindowsStoreApp)
            {
                BUT_betaupdate.Visible = false;
                BUT_updatecheck.Visible = false;
            }
        }

        public void BUT_updatecheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.WindowsStoreApp)
                {
                    return;
                }
                Utilities.Update.CheckForUpdate(true);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString(), Strings.ERROR);
            }
        }

        private void BUT_betaupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities.Update.dobeta = true;
                if (Control.ModifierKeys == Keys.Control)
                {
                    Utilities.Update.domaster = true;
                    CustomMessageBox.Show("This will update to MASTER release");
                }

                Utilities.Update.DoUpdate();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString(), Strings.ERROR);
            }
        }
    }
}