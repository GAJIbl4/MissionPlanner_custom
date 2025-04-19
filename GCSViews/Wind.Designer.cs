namespace MissionPlanner.GCSViews
{
    partial class Wind
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CHK_showconsole = new System.Windows.Forms.CheckBox();
            this.BUT_updatecheck = new MissionPlanner.Controls.MyButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BUT_betaupdate = new MissionPlanner.Controls.MyButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Name = "richTextBox1";
        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Controls.MyButton BUT_updatecheck;
        private System.Windows.Forms.CheckBox CHK_showconsole;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Controls.MyButton BUT_betaupdate;

    }
}
