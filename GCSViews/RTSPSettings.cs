using log4net;
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
    public partial class RTSPSettings : MyUserControl
    {

        internal static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public RTSPSettings()
        {
            InitializeComponent();
        }

        public void Activate()
        {
            log.Info("RTSP Settings activated");
            // Add activation logic here
        }
        public void Deactivate()
        {
            log.Info("RTSP Settings deactivated");
            // Add deactivation logic here
        }
    }
}
