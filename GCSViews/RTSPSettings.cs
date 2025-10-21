using log4net;
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
            this.loadSettings();
            // Add activation logic here
        }
        public void Deactivate()
        {
            log.Info("RTSP Settings deactivated");
            // Add deactivation logic here
        }

        private void loadSettings()
        {
            try
            {
                if (!Settings.Instance.ContainsKey("RTSPSettings"))
            {
                log.Info("RTSP Settings not found, creating default one");
                Settings.Instance["RTSP_URL"] = "192.168.1.33";
                Settings.Instance["RTSP_Port"] = "554";
                Settings.Instance["RTSP_login"] = "admin";
                Settings.Instance["RTSP_Password"] = "admin";
                Settings.Instance.Save();
            }

            this.IPTextBox.Text = Settings.Instance["RTSP_URL"];
            this.textBox1.Text = Settings.Instance["RTSP_Port"];
            this.textBox2.Text = Settings.Instance["RTSP_login"];
            this.textBox3.Text = Settings.Instance["RTSP_Password"]; }
            catch (Exception ex) {
                log.Error("RTSP Settings Error: ", ex);
            }

        }

        private void saveSettings()
        {
            if (this.checkBox1.Checked)
            {
                log.Info("RTSP Settings not found, creating default one");
                Settings.Instance["RTSP_URL"] = this.IPTextBox.Text;
                Settings.Instance["RTSP_Port"] = this.textBox1.Text;
                Settings.Instance["RTSP_login"] = this.textBox2.Text;
                Settings.Instance["RTSP_Password"] = this.textBox3.Text;
                Settings.Instance.Save();
            }
        }
    }
}
