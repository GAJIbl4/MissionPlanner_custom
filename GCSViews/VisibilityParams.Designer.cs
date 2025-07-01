namespace MissionPlanner.GCSViews
{
    partial class VisibilityParams
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuButtonsPage = new System.Windows.Forms.TabPage();
            this.menuButtonsChecklist = new System.Windows.Forms.CheckedListBox();
            this.mapContextMenuPage = new System.Windows.Forms.TabPage();
            this.mapContextMenuChecklist = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.menuButtonsPage.SuspendLayout();
            this.mapContextMenuPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.menuButtonsPage);
            this.tabControl1.Controls.Add(this.mapContextMenuPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1090, 629);
            this.tabControl1.TabIndex = 0;
            // 
            // menuButtonsPage
            // 
            this.menuButtonsPage.Controls.Add(this.menuButtonsChecklist);
            this.menuButtonsPage.Location = new System.Drawing.Point(4, 22);
            this.menuButtonsPage.Name = "menuButtonsPage";
            this.menuButtonsPage.Padding = new System.Windows.Forms.Padding(3);
            this.menuButtonsPage.Size = new System.Drawing.Size(1082, 603);
            this.menuButtonsPage.TabIndex = 0;
            this.menuButtonsPage.Text = "Menu buttons";
            this.menuButtonsPage.UseVisualStyleBackColor = true;
            // 
            // menuButtonsChecklist
            // 
            this.menuButtonsChecklist.CheckOnClick = true;
            this.menuButtonsChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButtonsChecklist.FormattingEnabled = true;
            this.menuButtonsChecklist.Location = new System.Drawing.Point(3, 3);
            this.menuButtonsChecklist.Name = "menuButtonsChecklist";
            this.menuButtonsChecklist.Size = new System.Drawing.Size(1076, 597);
            this.menuButtonsChecklist.TabIndex = 0;
            this.menuButtonsChecklist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.menuButtonsChecklist_ItemCheck);
            // 
            // mapContextMenuPage
            // 
            this.mapContextMenuPage.Controls.Add(this.mapContextMenuChecklist);
            this.mapContextMenuPage.Location = new System.Drawing.Point(4, 22);
            this.mapContextMenuPage.Name = "mapContextMenuPage";
            this.mapContextMenuPage.Padding = new System.Windows.Forms.Padding(3);
            this.mapContextMenuPage.Size = new System.Drawing.Size(1082, 603);
            this.mapContextMenuPage.TabIndex = 1;
            this.mapContextMenuPage.Text = "Map context menu";
            this.mapContextMenuPage.UseVisualStyleBackColor = true;
            // 
            // mapContextMenuChecklist
            // 
            this.mapContextMenuChecklist.CheckOnClick = true;
            this.mapContextMenuChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapContextMenuChecklist.FormattingEnabled = true;
            this.mapContextMenuChecklist.Location = new System.Drawing.Point(3, 3);
            this.mapContextMenuChecklist.Name = "mapContextMenuChecklist";
            this.mapContextMenuChecklist.Size = new System.Drawing.Size(1076, 597);
            this.mapContextMenuChecklist.TabIndex = 0;
            this.mapContextMenuChecklist.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.mapContextMenuChecklist_ItemCheck);
            // 
            // VisibilityParams
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "VisibilityParams";
            this.Size = new System.Drawing.Size(1090, 629);
            this.tabControl1.ResumeLayout(false);
            this.menuButtonsPage.ResumeLayout(false);
            this.mapContextMenuPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage menuButtonsPage;
        private System.Windows.Forms.TabPage mapContextMenuPage;
        private System.Windows.Forms.CheckedListBox menuButtonsChecklist;
        private System.Windows.Forms.CheckedListBox mapContextMenuChecklist;
    }
}
