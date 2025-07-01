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
using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews
{
    public partial class CustomParams : MyUserControl, IActivate, IDeactivate
    {
        internal static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public CustomParams()

        {
            InitializeComponent();
            log.Info("CustomParams constructor called");

        }
        public void Activate()
        {
            log.Info("CustomParams activated");
            // Add activation logic here
        }
        public void Deactivate()
        {
            log.Info("CustomParams deactivated");
            // Add deactivation logic here
        }
    }
}
