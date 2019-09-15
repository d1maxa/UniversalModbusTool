using UmtControls;
using UmtControls.CheckedComboBox;

namespace UmtExcelImport
{
    partial class BaseIndexEditor
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SpecialFunctionCheckedComboBox = new UmtControls.CheckedComboBox.CheckedComboBox();
            this.specialFunctionLabel = new System.Windows.Forms.Label();
            this.numericTextBox33 = new UmtControls.NumericTextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SpecialFunctionCheckedComboBox);
            this.panel1.Controls.Add(this.specialFunctionLabel);
            this.panel1.Controls.Add(this.numericTextBox33);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 116);
            this.panel1.TabIndex = 0;
            // 
            // SpecialFunctionCheckedComboBox
            // 
            this.SpecialFunctionCheckedComboBox.CheckOnClick = true;
            this.SpecialFunctionCheckedComboBox.DisplayMember = "Value";
            this.SpecialFunctionCheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SpecialFunctionCheckedComboBox.DropDownHeight = 1;
            this.SpecialFunctionCheckedComboBox.FormattingEnabled = true;
            this.SpecialFunctionCheckedComboBox.IntegralHeight = false;
            this.SpecialFunctionCheckedComboBox.Location = new System.Drawing.Point(95, 60);
            this.SpecialFunctionCheckedComboBox.Name = "SpecialFunctionCheckedComboBox";
            this.SpecialFunctionCheckedComboBox.Size = new System.Drawing.Size(275, 21);
            this.SpecialFunctionCheckedComboBox.TabIndex = 2;
            this.SpecialFunctionCheckedComboBox.ValueMember = "Key";
            this.SpecialFunctionCheckedComboBox.ValueSeparator = ", ";
            this.SpecialFunctionCheckedComboBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedComboBox1_ItemCheck);
            // 
            // specialFunctionLabel
            // 
            this.specialFunctionLabel.AutoSize = true;
            this.specialFunctionLabel.Location = new System.Drawing.Point(13, 63);
            this.specialFunctionLabel.Name = "specialFunctionLabel";
            this.specialFunctionLabel.Size = new System.Drawing.Size(68, 13);
            this.specialFunctionLabel.TabIndex = 3;
            this.specialFunctionLabel.Text = "Назначение";
            // 
            // numericTextBox33
            // 
            this.numericTextBox33.AllowSpace = false;
            this.numericTextBox33.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericTextBox33.Location = new System.Drawing.Point(95, 8);
            this.numericTextBox33.MaxLength = 9;
            this.numericTextBox33.Name = "numericTextBox33";
            this.numericTextBox33.OnlyPositiveInt = true;
            this.numericTextBox33.Size = new System.Drawing.Size(275, 20);
            this.numericTextBox33.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(UmtData.Data.Index.Base.BaseIndex);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Function", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(95, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 20);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource1, "IsReadOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("AutoCheck", this.bindingSource1, "CanChangeReadOnly", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(16, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Только для чтения";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес";
            // 
            // BaseIndexEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "BaseIndexEditor";
            this.Size = new System.Drawing.Size(390, 116);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.CheckBox checkBox1;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox textBox1;
        protected System.Windows.Forms.BindingSource bindingSource1;
        protected NumericTextBox numericTextBox33;
        protected System.Windows.Forms.Label specialFunctionLabel;
        protected CheckedComboBox SpecialFunctionCheckedComboBox;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}
