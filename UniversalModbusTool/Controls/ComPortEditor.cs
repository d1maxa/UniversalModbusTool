using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using UmtData.Data;
using UmtData.Data.Settings;
using UmtData.Helpers;

namespace UniversalModbusTool.Controls
{
    public partial class ComPortEditor : UserControl
    {
        public ComPortSetting ComPortSetting
        {
            get { return bindingSource1.DataSource as ComPortSetting; }
            set { bindingSource1.DataSource = value; }
        }

        public ComPortEditor(ComPortSetting comPortSetting)
        {
            InitializeComponent();

            ComPortSetting = comPortSetting;

            BaudRateComboBox.DataSource = (from int u in
                new[]
                {
                    110,
                    300,
                    600,
                    1200,
                    2400,
                    4800,
                    9600,
                    19200,
                    38400,
                    56000,
                    57600,
                    115200,
                    128000,
                    256000
                }
                select new KeyValuePair<int, string>(u, u.ToString())).ToList();

            DataBitsComboBox.DataSource = (from int u in new[]
            {
                5,
                6,
                7,
                8
            }
                select new KeyValuePair<int, string>(u, u.ToString())).ToList();

            StopBitsComboBox.DataSource = EnumHelper.GenerateValueListFromEnum<StopBits>();
            ParityComboBox.DataSource = EnumHelper.GenerateValueListFromEnum<Parity>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x =new ComPortSetting();
            ComPortSetting.BaudRate = x.BaudRate;
            ComPortSetting.DataBits = x.DataBits;
            ComPortSetting.Parity = x.Parity;
            ComPortSetting.StopBits = x.StopBits;
        }
    }
}
