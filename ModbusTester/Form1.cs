using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;
using ModbusTester.Properties;
using UmtControls;

namespace ModbusTester
{
    public partial class Form1 : Form
    {
        private readonly BindingList<ReadingValue> _list = new BindingList<ReadingValue>();

        public Form1()
        {
            InitializeComponent();
            //TypeComboBox.SelectedIndex = 0;
            var ports = SerialPort.GetPortNames();
            PortComboBox.DataSource = ports;
            //if (ports.Length > 0)PortComboBox.SelectedIndex = 0;
            readingValueBindingSource.DataSource = _list;
        }

        private void AutoReadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoReadCheckBox.Checked)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Read();
        }

        private ushort GetNumericTextBoxValue(NumericTextBox t)
        {
            ushort result;
            ushort.TryParse(t.Text, out result);
            return result;
        }

        private IModbusSerialMaster _master;
        private IModbusSerialMaster Master
        {
            get
            {
                if (_master != null)
                    return _master;
                var port = new SerialPort(PortComboBox.Text)
                {
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };

                // configure serial port
                port.Open();

                // create modbus master
                _master = ModbusSerialMaster.CreateRtu(port);
                _master.Transport.ReadTimeout = 1000;
                _master.Transport.Retries = 3;
                return _master;
            }
        }


        private void Read()
        {
            try
            {
                _list.Clear();
                

                var slaveId = Convert.ToByte(GetNumericTextBoxValue(SlaveNumericTextBox));
                var startAddress = GetNumericTextBoxValue(AddressNumericTextBox);
                var numRegisters = GetNumericTextBoxValue(NumberNumericTextBox);

                ushort[] result;
                switch (TypeComboBox.SelectedIndex)
                {
                    case 0:
                        result = Master.ReadCoils(slaveId, startAddress, numRegisters).Select(Convert.ToUInt16).ToArray();
                        break;
                    case 1:
                        result = Master.ReadInputs(slaveId, startAddress, numRegisters).Select(Convert.ToUInt16).ToArray();
                        break;
                    case 2:
                        result = Master.ReadInputRegisters(slaveId, startAddress, numRegisters);
                        break;
                    case 3:
                        result = Master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);
                        break;
                    default:
                        result = new ushort[0];
                        break;
                }
                
                for (ushort i = 0; i < numRegisters; i++)
                {
                    _list.Add(new ReadingValue()
                    {
                        Address = (startAddress + i).ToString(),
                        Value = result[i].ToString()
                    });
                }
                ErrorTextBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorTextBox.Text = ex.Message;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
