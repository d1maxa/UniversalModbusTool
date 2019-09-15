namespace UniversalModbusTool.Controls
{
    partial class ControllerListControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerListControl));
            this.flwContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.MonitoringToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TemperatureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PressureToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwContainer
            // 
            this.flwContainer.AutoScroll = true;
            this.flwContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flwContainer.Location = new System.Drawing.Point(3, 28);
            this.flwContainer.Name = "flwContainer";
            this.flwContainer.Size = new System.Drawing.Size(667, 206);
            this.flwContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flwContainer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 237);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MonitoringToolStripButton,
            this.TemperatureToolStripButton,
            this.PressureToolStripButton,
            this.AddToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(673, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // MonitoringToolStripButton
            // 
            this.MonitoringToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("MonitoringToolStripButton.Image")));
            this.MonitoringToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MonitoringToolStripButton.Name = "MonitoringToolStripButton";
            this.MonitoringToolStripButton.Size = new System.Drawing.Size(97, 22);
            this.MonitoringToolStripButton.Text = "Мониторинг";
            this.MonitoringToolStripButton.Click += new System.EventHandler(this.MonitoringToolStripButton_Click);
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.plus;
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(150, 22);
            this.AddToolStripButton.Text = "Добавить компрессор";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // TemperatureToolStripButton
            // 
            this.TemperatureToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.graph_blue;
            this.TemperatureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TemperatureToolStripButton.Name = "TemperatureToolStripButton";
            this.TemperatureToolStripButton.Size = new System.Drawing.Size(144, 22);
            this.TemperatureToolStripButton.Text = "График температуры";
            this.TemperatureToolStripButton.Click += new System.EventHandler(this.TemperatureToolStripButton_Click);
            // 
            // PressureToolStripButton
            // 
            this.PressureToolStripButton.Image = global::UniversalModbusTool.Properties.Resources.graph_green;
            this.PressureToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PressureToolStripButton.Name = "PressureToolStripButton";
            this.PressureToolStripButton.Size = new System.Drawing.Size(122, 22);
            this.PressureToolStripButton.Text = "График давления";
            this.PressureToolStripButton.Click += new System.EventHandler(this.PressureToolStripButton_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ControllerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ControllerListControl";
            this.Size = new System.Drawing.Size(673, 237);
            this.Load += new System.EventHandler(this.ControllerListControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flwContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripButton TemperatureToolStripButton;
        private System.Windows.Forms.ToolStripButton PressureToolStripButton;
        private System.Windows.Forms.ToolStripButton MonitoringToolStripButton;
    }
}
