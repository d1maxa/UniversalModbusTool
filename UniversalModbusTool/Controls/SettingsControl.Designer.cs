namespace UniversalModbusTool.Controls
{
    partial class SettingsControl
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
            this.numericTextBox1 = new UmtControls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new UmtControls.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericTextBox3 = new UmtControls.NumericTextBox();
            this.SuspendLayout();
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowSpace = false;
            this.numericTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::UniversalModbusTool.Properties.Settings.Default, "ReadTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox1.Location = new System.Drawing.Point(131, 3);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.OnlyPositiveInt = true;
            this.numericTextBox1.Size = new System.Drawing.Size(67, 20);
            this.numericTextBox1.TabIndex = 0;
            this.numericTextBox1.Text = global::UniversalModbusTool.Properties.Settings.Default.ReadTimeout;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таймаут чтения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Таймаут записи";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.AllowSpace = false;
            this.numericTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::UniversalModbusTool.Properties.Settings.Default, "WriteTimeout", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox2.Location = new System.Drawing.Point(131, 29);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.OnlyPositiveInt = true;
            this.numericTextBox2.Size = new System.Drawing.Size(67, 20);
            this.numericTextBox2.TabIndex = 3;
            this.numericTextBox2.Text = global::UniversalModbusTool.Properties.Settings.Default.WriteTimeout;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество попыток";
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.AllowSpace = false;
            this.numericTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::UniversalModbusTool.Properties.Settings.Default, "Retries", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox3.Location = new System.Drawing.Point(131, 55);
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.OnlyPositiveInt = true;
            this.numericTextBox3.Size = new System.Drawing.Size(67, 20);
            this.numericTextBox3.TabIndex = 5;
            this.numericTextBox3.Text = global::UniversalModbusTool.Properties.Settings.Default.Retries;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericTextBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericTextBox1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(399, 193);
            this.ParentChanged += new System.EventHandler(this.SettingsControl_ParentChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UmtControls.NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UmtControls.NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label3;
        private UmtControls.NumericTextBox numericTextBox3;
    }
}
