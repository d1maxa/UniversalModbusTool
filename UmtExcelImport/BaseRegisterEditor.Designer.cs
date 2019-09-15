using UmtControls;

namespace UmtExcelImport
{
    partial class BaseRegisterEditor
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericTextBox1 = new UmtControls.NumericTextBox();
            this.numericTextBox2 = new UmtControls.NumericTextBox();
            this.numericTextBox3 = new UmtControls.NumericTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(16, 242);
            this.checkBox1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.numericTextBox3);
            this.panel1.Controls.Add(this.numericTextBox2);
            this.panel1.Controls.Add(this.numericTextBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Size = new System.Drawing.Size(424, 267);
            this.panel1.Controls.SetChildIndex(this.SpecialFunctionCheckedComboBox, 0);
            this.panel1.Controls.SetChildIndex(this.specialFunctionLabel, 0);
            this.panel1.Controls.SetChildIndex(this.numericTextBox33, 0);
            this.panel1.Controls.SetChildIndex(this.label4, 0);
            this.panel1.Controls.SetChildIndex(this.label5, 0);
            this.panel1.Controls.SetChildIndex(this.label6, 0);
            this.panel1.Controls.SetChildIndex(this.label7, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.label2, 0);
            this.panel1.Controls.SetChildIndex(this.textBox1, 0);
            this.panel1.Controls.SetChildIndex(this.checkBox1, 0);
            this.panel1.Controls.SetChildIndex(this.textBox2, 0);
            this.panel1.Controls.SetChildIndex(this.numericTextBox1, 0);
            this.panel1.Controls.SetChildIndex(this.numericTextBox2, 0);
            this.panel1.Controls.SetChildIndex(this.numericTextBox3, 0);
            this.panel1.Controls.SetChildIndex(this.comboBox1, 0);
            this.panel1.Controls.SetChildIndex(this.label3, 0);
            this.panel1.Controls.SetChildIndex(this.comboBox2, 0);
            this.panel1.Controls.SetChildIndex(this.label8, 0);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 34);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(UmtData.Data.Index.Base.BaseRegister);
            // 
            // numericTextBox33
            // 
            this.numericTextBox33.Location = new System.Drawing.Point(130, 8);
            // 
            // SpecialFunctionCheckedComboBox
            // 
            this.SpecialFunctionCheckedComboBox.Location = new System.Drawing.Point(130, 60);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Единицы измерения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Мин. значение";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Макс. значение";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Множитель";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Units", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(130, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(275, 20);
            this.textBox2.TabIndex = 3;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.AllowSpace = false;
            this.numericTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox1.Location = new System.Drawing.Point(130, 111);
            this.numericTextBox1.MaxLength = 9;
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.OnlyPositiveInt = false;
            this.numericTextBox1.Size = new System.Drawing.Size(275, 20);
            this.numericTextBox1.TabIndex = 4;
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.AllowSpace = false;
            this.numericTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox2.Location = new System.Drawing.Point(130, 137);
            this.numericTextBox2.MaxLength = 9;
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.OnlyPositiveInt = false;
            this.numericTextBox2.Size = new System.Drawing.Size(275, 20);
            this.numericTextBox2.TabIndex = 5;
            // 
            // numericTextBox3
            // 
            this.numericTextBox3.AllowSpace = false;
            this.numericTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Multiplier", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox3.Location = new System.Drawing.Point(130, 163);
            this.numericTextBox3.MaxLength = 9;
            this.numericTextBox3.Name = "numericTextBox3";
            this.numericTextBox3.OnlyPositiveInt = false;
            this.numericTextBox3.Size = new System.Drawing.Size(275, 20);
            this.numericTextBox3.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "CustomType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(130, 217);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(275, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Особый тип данных";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource1, "DataType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox2.DisplayMember = "Value";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 189);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(275, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.ValueMember = "Key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Тип данных";
            // 
            // BaseRegisterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseRegisterEditor";
            this.Size = new System.Drawing.Size(424, 267);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private NumericTextBox numericTextBox3;
        private NumericTextBox numericTextBox2;
        private NumericTextBox numericTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label8;
    }
}
