namespace MissionPlanner.GCSViews
{
    partial class CustomParams
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
            this.configMyParams1 = new MissionPlanner.GCSViews.ConfigurationView.configMyParams();
            this.SuspendLayout();
            // 
            // configMyParams1
            // 
            this.configMyParams1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configMyParams1.Location = new System.Drawing.Point(0, 0);
            this.configMyParams1.Name = "configMyParams1";
            this.configMyParams1.Size = new System.Drawing.Size(852, 518);
            this.configMyParams1.TabIndex = 0;
            // 
            // CustomParams
            // 
            this.Controls.Add(this.configMyParams1);
            this.Name = "CustomParams";
            this.Size = new System.Drawing.Size(852, 518);
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigurationView.configMyParams configMyParams;
        private ConfigurationView.configMyParams configMyParams1;
    }
}
