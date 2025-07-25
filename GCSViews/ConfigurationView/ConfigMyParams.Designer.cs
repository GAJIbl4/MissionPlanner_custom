﻿namespace MissionPlanner.GCSViews.ConfigurationView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.writeButton = new MissionPlanner.Controls.MyButton();
            this.refreshButton = new MissionPlanner.Controls.MyButton();
            this.unsavedLabel = new System.Windows.Forms.Label();
            this.Params = new MissionPlanner.Controls.MyDataGridView();
            this.OptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Options = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fav = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Params)).BeginInit();
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.writeButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.refreshButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.unsavedLabel, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(773, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
            // unsavedLabel
            // 
            this.unsavedLabel.AutoSize = true;
            this.unsavedLabel.BackColor = System.Drawing.Color.Khaki;
            this.unsavedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unsavedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.unsavedLabel.Location = new System.Drawing.Point(3, 58);
            this.unsavedLabel.Name = "unsavedLabel";
            this.unsavedLabel.Size = new System.Drawing.Size(153, 568);
            this.unsavedLabel.TabIndex = 2;
            this.unsavedLabel.Text = "U\r\nN\r\nS\r\nA\r\nV\r\nE\r\nD";
            this.unsavedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unsavedLabel.Visible = false;
            // 
            // Params
            // 
            this.Params.AllowUserToAddRows = false;
            this.Params.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Params.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptionName,
            this.Value,
            this.Default,
            this.Units,
            this.Options,
            this.Desc,
            this.Fav});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.DefaultCellStyle = dataGridViewCellStyle7;
            this.Params.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Params.Location = new System.Drawing.Point(3, 3);
            this.Params.Name = "Params";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Params.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Params.RowHeadersVisible = false;
            this.Params.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.Params.Size = new System.Drawing.Size(764, 626);
            this.Params.TabIndex = 72;
            this.Params.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Params_CellValueChanged);
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
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Desc.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Params)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.MyButton writeButton;
        private Controls.MyButton refreshButton;
        private Controls.MyDataGridView Params;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn Options;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Fav;
        private System.Windows.Forms.Label unsavedLabel;
    }
}
