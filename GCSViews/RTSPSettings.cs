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
            try
            {
                this.loadSettings();
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
                if (!Settings.Instance.ContainsKey("RTSPSettings"))
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
            this.textBox3.Text = Settings.Instance["RTSP_Password"]; }
            catch (Exception ex) {
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
}
