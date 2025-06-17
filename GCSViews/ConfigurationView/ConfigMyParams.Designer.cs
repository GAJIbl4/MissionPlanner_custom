namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class configMyParams
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Params = new MissionPlanner.Controls.MyDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.writeButton = new MissionPlanner.Controls.MyButton();
            this.refreshButton = new MissionPlanner.Controls.MyButton();
            this.compareButton = new MissionPlanner.Controls.MyButton();
            this.OptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Options = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fav = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Params)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.Params, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(935, 632);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Params
            // 
            this.Params.AllowUserToAddRows = false;
            this.Params.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptionName,
            this.Value,
            this.Default,
            this.Units,
            this.Options,
            this.Desc,
            this.Fav});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.DefaultCellStyle = dataGridViewCellStyle3;
            this.Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Params.Location = new System.Drawing.Point(3, 3);
            this.Params.Name = "Params";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Params.RowHeadersVisible = false;
            this.Params.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Params.Size = new System.Drawing.Size(764, 626);
            this.Params.TabIndex = 72;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.writeButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.refreshButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.compareButton, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(773, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(159, 626);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // writeButton
            // 
            this.writeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.writeButton.Location = new System.Drawing.Point(3, 3);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(153, 23);
            this.writeButton.TabIndex = 0;
            this.writeButton.Text = "Записать";
            this.writeButton.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshButton.Location = new System.Drawing.Point(3, 32);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(153, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // compareButton
            // 
            this.compareButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.compareButton.Location = new System.Drawing.Point(3, 61);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(153, 23);
            this.compareButton.TabIndex = 2;
            this.compareButton.Text = "Сравнить";
            this.compareButton.TextColorNotEnabled = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(87)))), ((int)(((byte)(4)))));
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Visible = false;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // OptionName
            // 
            this.OptionName.FillWeight = 20F;
            this.OptionName.HeaderText = "Название";
            this.OptionName.MinimumWidth = 50;
            this.OptionName.Name = "OptionName";
            this.OptionName.ReadOnly = true;
            this.OptionName.Width = 130;
            // 
            // Value
            // 
            this.Value.FillWeight = 11F;
            this.Value.HeaderText = "Значение";
            this.Value.MinimumWidth = 50;
            this.Value.Name = "Value";
            this.Value.Width = 70;
            // 
            // Default
            // 
            this.Default.FillWeight = 11F;
            this.Default.HeaderText = "По умолчанию";
            this.Default.MinimumWidth = 50;
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            this.Default.Visible = false;
            this.Default.Width = 70;
            // 
            // Units
            // 
            this.Units.FillWeight = 9F;
            this.Units.HeaderText = "Ед. изм.";
            this.Units.MinimumWidth = 50;
            this.Units.Name = "Units";
            this.Units.ReadOnly = true;
            this.Units.Width = 60;
            // 
            // Options
            // 
            this.Options.FillWeight = 28F;
            this.Options.HeaderText = "Варианты";
            this.Options.MinimumWidth = 50;
            this.Options.Name = "Options";
            this.Options.ReadOnly = true;
            this.Options.Visible = false;
            this.Options.Width = 150;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Desc.DefaultCellStyle = dataGridViewCellStyle2;
            this.Desc.FillWeight = 25F;
            this.Desc.HeaderText = "Описание";
            this.Desc.MinimumWidth = 50;
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            // 
            // Fav
            // 
            this.Fav.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fav.FillWeight = 4F;
            this.Fav.HeaderText = "Fav";
            this.Fav.MinimumWidth = 30;
            this.Fav.Name = "Fav";
            this.Fav.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Fav.Visible = false;
            this.Fav.Width = 30;
            // 
            // configMyParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "configMyParams";
            this.Size = new System.Drawing.Size(935, 632);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Params)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.MyButton writeButton;
        private Controls.MyButton refreshButton;
        private Controls.MyButton compareButton;
        private Controls.MyDataGridView Params;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn Options;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fav;
    }
}
