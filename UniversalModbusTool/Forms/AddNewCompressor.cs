using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UmtData.Data.Settings;
using UniversalModbusTool.Core;

namespace UniversalModbusTool.Forms
{
    public partial class AddNewCompressor : Form
    {
        private readonly bool _isNew;

        public CompressorSetting CompressorSetting
        {
            get { return compressorSettingBindingSource.DataSource as CompressorSetting; }
            set { compressorSettingBindingSource.DataSource = value; }
        }

        public AddNewCompressor(CompressorSetting setting, bool isNew)
        {
            _isNew = isNew;
            InitializeComponent();

            CompressorSetting = setting;

            ComPortInitializer.Initialize();
            Options.Instance.LoadCompressorIndexes();

            TypeComboBox.DataSource = Options.Instance.CompressorIndexes.Select(u => new KeyValuePair<string, string>(u.Name, u.Name)).ToList();
            ComPortComboBox.DataSource = Options.Instance.ComPortSettings.Select(u => new KeyValuePair<string, string>(u.Name, u.Name)).ToList();
            if (!isNew)
                Text = "Редактировать компрессор";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new SearchAddress(CompressorSetting))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CompressorSetting.Address = dlg.Address;
                }
            }
        }
        
        private void ComPortComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SearchButton.Enabled = ComPortComboBox.SelectedValue != null;

            byte a = 0;
            byte.TryParse(InnerAddressNumericTextBox.Text, out a);

            OkButton.Enabled = TypeComboBox.SelectedValue != null && ComPortComboBox.SelectedValue != null && a > 0;
        }

        private void AddNewCompressor_Load(object sender, EventArgs e)
        {
            if (_isNew)
            {
                if (Options.Instance.CompressorIndexes.Count > 0)
                    TypeComboBox.SelectedIndex = 0;
                if (Options.Instance.ComPortSettings.Count > 0)
                    ComPortComboBox.SelectedIndex = 0;
            }
        }
    }
}
