namespace UniversalModbusTool.Forms
{
    partial class Graph
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ClearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AutoRefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IntervalNumericTextBox = new UmtControls.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberNumericTextBox = new UmtControls.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.PointCheckBox = new System.Windows.Forms.CheckBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(552, 440);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 471);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripButton,
            this.ClearToolStripButton,
            this.AutoRefreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.save;
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Size = new System.Drawing.Size(115, 22);
            this.SaveToolStripButton.Text = "Сохранить как...";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // ClearToolStripButton
            // 
            this.ClearToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.clear;
            this.ClearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearToolStripButton.Name = "ClearToolStripButton";
            this.ClearToolStripButton.Size = new System.Drawing.Size(122, 22);
            this.ClearToolStripButton.Text = "Очистить график";
            this.ClearToolStripButton.Visible = false;
            this.ClearToolStripButton.Click += new System.EventHandler(this.ClearToolStripButton_Click);
            // 
            // AutoRefreshToolStripButton
            // 
            this.AutoRefreshToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.refresh;
            this.AutoRefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoRefreshToolStripButton.Name = "AutoRefreshToolStripButton";
            this.AutoRefreshToolStripButton.Size = new System.Drawing.Size(120, 22);
            this.AutoRefreshToolStripButton.Text = "Автообновление";
            this.AutoRefreshToolStripButton.Click += new System.EventHandler(this.AutoRefreshToolStripButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 440);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.IntervalNumericTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NumberNumericTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ValuesCheckBox);
            this.groupBox1.Controls.Add(this.PointCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(561, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 440);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "c";
            // 
            // IntervalNumericTextBox
            // 
            this.IntervalNumericTextBox.AllowSpace = false;
            this.IntervalNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::UniversalModbusTool.Properties.Settings.Default, "Interval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IntervalNumericTextBox.Location = new System.Drawing.Point(6, 133);
            this.IntervalNumericTextBox.Name = "IntervalNumericTextBox";
            this.IntervalNumericTextBox.OnlyPositiveInt = false;
            this.IntervalNumericTextBox.Size = new System.Drawing.Size(56, 20);
            this.IntervalNumericTextBox.TabIndex = 6;
            this.IntervalNumericTextBox.Text = global::UniversalModbusTool.Properties.Settings.Default.Interval;
            this.IntervalNumericTextBox.TextChanged += new System.EventHandler(this.IntervalNumericTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Интервал между значениями";
            // 
            // NumberNumericTextBox
            // 
            this.NumberNumericTextBox.AllowSpace = false;
            this.NumberNumericTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::UniversalModbusTool.Properties.Settings.Default, "NumberOfValuesOnGraph", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumberNumericTextBox.Location = new System.Drawing.Point(6, 83);
            this.NumberNumericTextBox.Name = "NumberNumericTextBox";
            this.NumberNumericTextBox.OnlyPositiveInt = false;
            this.NumberNumericTextBox.Size = new System.Drawing.Size(56, 20);
            this.NumberNumericTextBox.TabIndex = 4;
            this.NumberNumericTextBox.Text = global::UniversalModbusTool.Properties.Settings.Default.NumberOfValuesOnGraph;
            this.NumberNumericTextBox.TextChanged += new System.EventHandler(this.NumberNumericTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Количество значений на экране";
            // 
            // ValuesCheckBox
            // 
            this.ValuesCheckBox.AutoSize = true;
            this.ValuesCheckBox.Checked = global::UniversalModbusTool.Properties.Settings.Default.IsValues;
            this.ValuesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::UniversalModbusTool.Properties.Settings.Default, "IsValues", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ValuesCheckBox.Location = new System.Drawing.Point(6, 42);
            this.ValuesCheckBox.Name = "ValuesCheckBox";
            this.ValuesCheckBox.Size = new System.Drawing.Size(74, 17);
            this.ValuesCheckBox.TabIndex = 1;
            this.ValuesCheckBox.Text = "Значения";
            this.ValuesCheckBox.UseVisualStyleBackColor = true;
            this.ValuesCheckBox.CheckedChanged += new System.EventHandler(this.ValuesCheckBox_CheckedChanged);
            // 
            // PointCheckBox
            // 
            this.PointCheckBox.AutoSize = true;
            this.PointCheckBox.Checked = global::UniversalModbusTool.Properties.Settings.Default.IsPoints;
            this.PointCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::UniversalModbusTool.Properties.Settings.Default, "IsPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PointCheckBox.Location = new System.Drawing.Point(6, 19);
            this.PointCheckBox.Name = "PointCheckBox";
            this.PointCheckBox.Size = new System.Drawing.Size(56, 17);
            this.PointCheckBox.TabIndex = 0;
            this.PointCheckBox.Text = "Точки";
            this.PointCheckBox.UseVisualStyleBackColor = true;
            this.PointCheckBox.CheckedChanged += new System.EventHandler(this.PointCheckBox_CheckedChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "График";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton ClearToolStripButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox PointCheckBox;
        private System.Windows.Forms.CheckBox ValuesCheckBox;
        private UmtControls.NumericTextBox NumberNumericTextBox;
        private System.Windows.Forms.Label label1;
        private UmtControls.NumericTextBox IntervalNumericTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolStripButton;
    }
}