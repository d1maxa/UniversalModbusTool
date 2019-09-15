using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Modbus.Device;
using UmtData.Data;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Data.Settings;
using UmtData.Helpers;
using UniversalModbusTool.Core;
using UniversalModbusTool.Forms;
using UniversalModbusTool.Interface;

namespace UniversalModbusTool.Controls
{
    public partial class CompressorItemControl : BaseUserControl
    {
        private readonly ICompressorListControl _parent;

        public CompressorSetting CompressorSetting
        {
            get { return CompressorSettingBindingSource.DataSource as CompressorSetting; }
            set { CompressorSettingBindingSource.DataSource = value; }
        }

        public Thread RefreshThread { get; set; }
        
        public CompressorItemControl(CompressorSetting compressorSetting, ICompressorListControl parent)
        {
            _parent = parent;
            InitializeComponent();
            CompressorData = new CompressorData();
            CompressorSetting = compressorSetting;
        }

        private CompressorData CompressorData
        {
            get { return compressorDataBindingSource.DataSource as CompressorData; }
            set { compressorDataBindingSource.DataSource = value; }
        }
        
        #region Кнопки

        private void WriteFunction(SpecialFunction function, SpecialFunction function0 = SpecialFunction.None)
        {
            var x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(function));
            if (x != null)
                ModbusTool.Write(x.Index, CompressorSetting, 1);
            else if (function0 != SpecialFunction.None)
            {
                x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(function0));
                if (x != null)
                    ModbusTool.Write(x.Index, CompressorSetting, 0);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            WriteFunction(SpecialFunction.StartButton, SpecialFunction.StartButton0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            WriteFunction(SpecialFunction.StopButton, SpecialFunction.StopButton0);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            WriteFunction(SpecialFunction.ResetButton, SpecialFunction.ResetButton0);
        }

        #endregion
        
        public void StartRefreshIndexesThread()
        {
            new Thread(RefreshIndexes).Start();
        }

        public void RefreshIndexes()
        {
            var defaultValue = "-";

            var x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(SpecialFunction.Pressure));
            string temp;
            if (x != null)
            {
                var z = ModbusTool.Read(x.Index, CompressorSetting);
                temp = z.ToString();
                CompressorSetting.AddPressure(DateTime.Now, z);
            }
            else
                temp = defaultValue;

            Invoke(() => CompressorData.Pressure = temp);

            string temp2;
            x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(SpecialFunction.Temperature));
            if (x != null)
            {
                var z = ModbusTool.Read(x.Index, CompressorSetting);
                temp2 = z.ToString();
                CompressorSetting.AddTemperature(DateTime.Now, z);
            }
            else
            {
                temp2 = defaultValue;
            }

            Invoke(() => CompressorData.Temperature = temp2);

            bool? temp3 = null;
            x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(SpecialFunction.Status));
            if (x != null)
            {
                temp3 = ModbusTool.Read(x.Index, CompressorSetting) == 1;
            }
            else
            {
                x = CompressorSetting.Indexes?.SpecialFunctions.FirstOrDefault(u => u.SpecialFunction.HasFlag(SpecialFunction.Status0));
                if (x != null)
                {
                    temp3 = ModbusTool.Read(x.Index, CompressorSetting) == 0;
                }
            }

            Invoke(() => CompressorData.InnerStatus = temp3);
        }

        private void btnControllerMenu_Click(object sender, EventArgs e)
        {
            using (var dlg = new CompressorMenu(CompressorSetting))
            {
                dlg.ShowDialog();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _parent.RemoveCompressor(this);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            _parent.EditCompressor(this);
        }
    }
}
