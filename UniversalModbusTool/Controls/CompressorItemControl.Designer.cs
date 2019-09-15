namespace UniversalModbusTool.Controls
{
    partial class CompressorItemControl
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SerialLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.compressorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnControllerMenu = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PressureLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ModelLabel = new System.Windows.Forms.Label();
            this.CompressorSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressorDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompressorSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.RemoveButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.NumberLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SerialLabel);
            this.panel1.Controls.Add(this.ResetButton);
            this.panel1.Controls.Add(this.btnControllerMenu);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.TemperatureLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.PressureLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ModelLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 189);
            this.panel1.TabIndex = 4;
            // 
            // EditButton
            // 
            this.EditButton.Image = global::UniversalModbusTool.Properties.Resources.Hammer;
            this.EditButton.Location = new System.Drawing.Point(294, 6);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(25, 25);
            this.EditButton.TabIndex = 28;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Image = global::UniversalModbusTool.Properties.Resources.Cross;
            this.RemoveButton.Location = new System.Drawing.Point(325, 6);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(25, 25);
            this.RemoveButton.TabIndex = 27;
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(14, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Номер";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CompressorSettingBindingSource, "Number", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberLabel.Location = new System.Drawing.Point(13, 105);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(95, 20);
            this.NumberLabel.TabIndex = 25;
            this.NumberLabel.Text = "DX 200 - 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(14, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Серийный номер";
            // 
            // SerialLabel
            // 
            this.SerialLabel.AutoSize = true;
            this.SerialLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CompressorSettingBindingSource, "SerialNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialLabel.Location = new System.Drawing.Point(13, 65);
            this.SerialLabel.Name = "SerialLabel";
            this.SerialLabel.Size = new System.Drawing.Size(95, 20);
            this.SerialLabel.TabIndex = 23;
            this.SerialLabel.Text = "DX 200 - 1";
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ResetButton.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.compressorDataBindingSource, "ResetColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ResetButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.compressorDataBindingSource, "ResetEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ResetButton.Location = new System.Drawing.Point(175, 143);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 33);
            this.ResetButton.TabIndex = 22;
            this.ResetButton.Text = "Сброс";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // compressorDataBindingSource
            // 
            this.compressorDataBindingSource.DataSource = typeof(UmtData.Data.CompressorData);
            // 
            // btnControllerMenu
            // 
            this.btnControllerMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControllerMenu.Location = new System.Drawing.Point(256, 143);
            this.btnControllerMenu.Name = "btnControllerMenu";
            this.btnControllerMenu.Size = new System.Drawing.Size(79, 33);
            this.btnControllerMenu.TabIndex = 21;
            this.btnControllerMenu.Text = "Показатели";
            this.btnControllerMenu.UseVisualStyleBackColor = true;
            this.btnControllerMenu.Click += new System.EventHandler(this.btnControllerMenu_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.compressorDataBindingSource, "StopColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnStop.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.compressorDataBindingSource, "StopEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnStop.Location = new System.Drawing.Point(94, 143);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 33);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.YellowGreen;
            this.btnStart.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", this.compressorDataBindingSource, "StartColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnStart.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.compressorDataBindingSource, "StartEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnStart.Location = new System.Drawing.Point(13, 143);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 33);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compressorDataBindingSource, "Temperature", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TemperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TemperatureLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TemperatureLabel.Location = new System.Drawing.Point(181, 107);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(38, 25);
            this.TemperatureLabel.TabIndex = 18;
            this.TemperatureLabel.Text = "70";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(183, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Температура (C)";
            // 
            // PressureLabel
            // 
            this.PressureLabel.AutoSize = true;
            this.PressureLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compressorDataBindingSource, "Pressure", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PressureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PressureLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.PressureLabel.Location = new System.Drawing.Point(180, 66);
            this.PressureLabel.Name = "PressureLabel";
            this.PressureLabel.Size = new System.Drawing.Size(58, 25);
            this.PressureLabel.TabIndex = 16;
            this.PressureLabel.Text = "85.2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(182, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Давление (BAR)";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compressorDataBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblStatus.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", this.compressorDataBindingSource, "StatusColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblStatus.Location = new System.Drawing.Point(181, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(90, 20);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Работает";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(183, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Статус";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Модель";
            // 
            // ModelLabel
            // 
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CompressorSettingBindingSource, "IndexesName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelLabel.Location = new System.Drawing.Point(13, 27);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(95, 20);
            this.ModelLabel.TabIndex = 11;
            this.ModelLabel.Text = "DX 200 - 1";
            // 
            // CompressorSettingBindingSource
            // 
            this.CompressorSettingBindingSource.DataSource = typeof(UmtData.Data.Settings.CompressorSetting);
            // 
            // CompressorItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "CompressorItemControl";
            this.Size = new System.Drawing.Size(385, 192);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressorDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompressorSettingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnControllerMenu;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label PressureLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ModelLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.BindingSource compressorDataBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SerialLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.BindingSource CompressorSettingBindingSource;
    }
}
