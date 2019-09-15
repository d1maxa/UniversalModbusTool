namespace ModbusTester
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ReadButton = new System.Windows.Forms.Button();
            this.AutoReadCheckBox = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.NumberNumericTextBox = new UmtControls.NumericTextBox();
            this.AddressNumericTextBox = new UmtControls.NumericTextBox();
            this.SlaveNumericTextBox = new UmtControls.NumericTextBox();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readingValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readingValueBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.readingValueBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 224);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(409, 276);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SlaveId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "NumberOfPoints";
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(15, 168);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(75, 23);
            this.ReadButton.TabIndex = 13;
            this.ReadButton.Text = "Read";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // AutoReadCheckBox
            // 
            this.AutoReadCheckBox.AutoSize = true;
            this.AutoReadCheckBox.Location = new System.Drawing.Point(15, 145);
            this.AutoReadCheckBox.Name = "AutoReadCheckBox";
            this.AutoReadCheckBox.Size = new System.Drawing.Size(77, 17);
            this.AutoReadCheckBox.TabIndex = 14;
            this.AutoReadCheckBox.Text = "Auto Read";
            this.AutoReadCheckBox.UseVisualStyleBackColor = true;
            this.AutoReadCheckBox.CheckedChanged += new System.EventHandler(this.AutoReadCheckBox_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NumberNumericTextBox
            // 
            this.NumberNumericTextBox.AllowSpace = false;
            this.NumberNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModbusTester.Properties.Settings.Default, "NumRegisters", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumberNumericTextBox.Location = new System.Drawing.Point(102, 118);
            this.NumberNumericTextBox.Name = "NumberNumericTextBox";
            this.NumberNumericTextBox.OnlyPositiveInt = true;
            this.NumberNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.NumberNumericTextBox.TabIndex = 12;
            this.NumberNumericTextBox.Text = global::ModbusTester.Properties.Settings.Default.NumRegisters;
            // 
            // AddressNumericTextBox
            // 
            this.AddressNumericTextBox.AllowSpace = false;
            this.AddressNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModbusTester.Properties.Settings.Default, "StartAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AddressNumericTextBox.Location = new System.Drawing.Point(102, 92);
            this.AddressNumericTextBox.Name = "AddressNumericTextBox";
            this.AddressNumericTextBox.OnlyPositiveInt = true;
            this.AddressNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.AddressNumericTextBox.TabIndex = 10;
            this.AddressNumericTextBox.Text = global::ModbusTester.Properties.Settings.Default.StartAddress;
            // 
            // SlaveNumericTextBox
            // 
            this.SlaveNumericTextBox.AllowSpace = false;
            this.SlaveNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModbusTester.Properties.Settings.Default, "SlaveAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SlaveNumericTextBox.Location = new System.Drawing.Point(102, 66);
            this.SlaveNumericTextBox.Name = "SlaveNumericTextBox";
            this.SlaveNumericTextBox.OnlyPositiveInt = true;
            this.SlaveNumericTextBox.Size = new System.Drawing.Size(100, 20);
            this.SlaveNumericTextBox.TabIndex = 8;
            this.SlaveNumericTextBox.Text = global::ModbusTester.Properties.Settings.Default.SlaveAddress;
            // 
            // PortComboBox
            // 
            this.PortComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModbusTester.Properties.Settings.Default, "Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(102, 39);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 21);
            this.PortComboBox.TabIndex = 6;
            this.PortComboBox.Text = global::ModbusTester.Properties.Settings.Default.Port;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ModbusTester.Properties.Settings.Default, "Type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "Coil",
            "InputStatus",
            "InputRegister",
            "HoldingRegister"});
            this.TypeComboBox.Location = new System.Drawing.Point(102, 12);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.TypeComboBox.TabIndex = 3;
            this.TypeComboBox.Text = global::ModbusTester.Properties.Settings.Default.Type;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // readingValueBindingSource
            // 
            this.readingValueBindingSource.DataSource = typeof(ModbusTester.ReadingValue);
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorTextBox.Location = new System.Drawing.Point(241, 10);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.Size = new System.Drawing.Size(156, 196);
            this.ErrorTextBox.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 500);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.AutoReadCheckBox);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.NumberNumericTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddressNumericTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SlaveNumericTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "ModbusTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readingValueBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Label label3;
        private UmtControls.NumericTextBox SlaveNumericTextBox;
        private System.Windows.Forms.Label label4;
        private UmtControls.NumericTextBox AddressNumericTextBox;
        private UmtControls.NumericTextBox NumberNumericTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.CheckBox AutoReadCheckBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource readingValueBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox ErrorTextBox;
    }
}

