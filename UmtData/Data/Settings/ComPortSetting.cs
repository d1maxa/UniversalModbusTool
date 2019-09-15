using System;
using System.ComponentModel;
using System.IO.Ports;
using Modbus.Device;
using PropertyChanged;
using UmtData.Helpers;

namespace UmtData.Data.Settings
{
    [ImplementPropertyChanged]
    public class ComPortSetting
    {
        public string Name { get; set; } = "-";

        public int BaudRate { get; set; } = 9600;

        public int DataBits { get; set; } = 8;

        public StopBits StopBits { get; set; } = StopBits.One;

        public Parity Parity { get; set; } = Parity.None;
        
        private SerialPort _port;
        public SerialPort SerialPort
        {
            get
            {
                if (_port != null && _port.IsOpen)
                    return _port;

                _port = new SerialPort(Name)
                {
                    BaudRate = BaudRate,
                    DataBits = DataBits,
                    Parity = Parity,
                    StopBits = StopBits
                };

                // configure serial port
                _port.Open();

                return _port;
            }
        }

        public void ClosePort()
        {
            if (_port != null && _port.IsOpen)
                _port.Close();
        }

        private ModbusSerialMaster _master;
        public ModbusSerialMaster Master
        {
            get
            {
                if (_master != null)
                {
                    return _master;
                }

                // create modbus master
                var port = SerialPort;
                if (port == null || !port.IsOpen)
                    return null;

                _master = ModbusSerialMaster.CreateRtu(port);
                InitMaster();
                return _master;
            }
        }

        public void InitMaster()
        {
            if (_master != null)
            {
                _master.Transport.ReadTimeout = TransportSetting.ReadTimeout;
                _master.Transport.WriteTimeout = TransportSetting.WriteTimeout;
                _master.Transport.Retries = TransportSetting.Retries;
            }
        }

        ~ComPortSetting()
        {
            ClosePort();
        }
    }
}
