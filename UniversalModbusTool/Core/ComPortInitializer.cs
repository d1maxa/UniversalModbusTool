using System.IO.Ports;
using System.Linq;
using UmtData.Data.Settings;

namespace UniversalModbusTool.Core
{
    public static class ComPortInitializer
    {
        /// <summary>
        /// Инициализирует com-порты
        /// </summary>
        /// <returns></returns>
        public static void Initialize()
        {
            var ports = SerialPort.GetPortNames();
            var options = Options.Instance;
            foreach (var port in ports)
            {
                var x = options.ComPortSettings.FirstOrDefault(u => u.Name == port);
                if (x == null)
                {
                    x = new ComPortSetting()
                    {
                        Name = port
                    };
                    options.ComPortSettings.Add(x);
                    options.SaveComPorts();
                }
            }
        }
        
    }
}