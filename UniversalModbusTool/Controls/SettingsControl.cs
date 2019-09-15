using System;
using System.Windows.Forms;
using UmtData.Data.Settings;
using UniversalModbusTool.Properties;

namespace UniversalModbusTool.Controls
{
    public partial class SettingsControl : BaseUserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void SettingsControl_ParentChanged(object sender, EventArgs e)
        {
            Settings.Save();
            TransportSetting.ReadTimeout = GetSetting(Settings.ReadTimeout);
            TransportSetting.WriteTimeout = GetSetting(Settings.WriteTimeout);
            TransportSetting.Retries = GetSetting(Settings.Retries);
            Options.InitMasterSettings();
        }

        private int GetSetting(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;
            int result;
            Int32.TryParse(s, out result);
            return result;
        }
    }
}
