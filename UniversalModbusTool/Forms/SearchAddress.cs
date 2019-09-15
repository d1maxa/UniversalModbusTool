using System;
using System.Drawing;
using System.Windows.Forms;
using Modbus.Device;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Data.Settings;
using UniversalModbusTool.Core;

namespace UniversalModbusTool.Forms
{
    public partial class SearchAddress : Form
    {
        private readonly CompressorSetting _setting;

        public byte Address = 0;

        public SearchAddress(CompressorSetting setting)
        {
            _setting = setting;
            InitializeComponent();

            portLabel.Text = "Порт " + setting.ComPortName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte start; 
            if (!byte.TryParse(StartNumericTextBox.Text, out start))
            {
                start = 1;
                StartNumericTextBox.Text = start.ToString();
            }
            byte finish;
            if (!byte.TryParse(FinishTextBox.Text, out finish))
            {
                finish = 255;
                FinishTextBox.Text = finish.ToString();
            }

            flowLayoutPanel1.Controls.Clear();

            var coil = new CoilStatus()
            {
                Address = 1
            };

            for (var i = start; i <= finish && i >= start; i++)
            {
                var button = new Button()
                {
                    Text = i.ToString()
                };

                try
                {
                    ModbusTool.Read(coil, _setting, i);
                    button.ForeColor = Color.Green;
                }
                catch (Exception)
                {
                    button.ForeColor = Color.Red;
                }
                button.Click += (o, args) =>
                {
                    var b = o as Button;
                    if (b != null && b.ForeColor == Color.Green)
                    {
                        Address = Convert.ToByte(b.Text);
                        DialogResult = DialogResult.OK;
                    }
                };
                flowLayoutPanel1.Controls.Add(button);
                Application.DoEvents();
            }
        }
    }
}
