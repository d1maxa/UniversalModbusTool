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
    public partial class ComPortList : UserControl
    {
        public ComPortList()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            var ports = SerialPort.GetPortNames();
            listTextBox.Text = ports.Length == 0 ? "(не обнаружены)" : string.Join(Environment.NewLine, ports);
        }
    }
}
