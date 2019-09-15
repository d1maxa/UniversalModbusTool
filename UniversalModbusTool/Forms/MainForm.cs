using System;
using System.Windows.Forms;
using UniversalModbusTool.Controls;

namespace UniversalModbusTool.Forms
{
    public partial class MainForm : BaseForm
    {
        private static TextBox _errorTextBox;

        private readonly Lazy<ControllerListControl> _controllerListControl = new Lazy<ControllerListControl>(() => new ControllerListControl(_errorTextBox));
        private readonly Lazy<SettingsControl> _settingsControl = new Lazy<SettingsControl>(() => new SettingsControl());
        private readonly Lazy<ComPortListControl> _comPortListControl = new Lazy<ComPortListControl>(() => new ComPortListControl());
        
        public MainForm()
        {
            InitializeComponent();
            _errorTextBox = ErrorTextBox;
            LoadOptions();
            ShowCompressors();
        }

        private void LoadOptions()
        {
            Options.LoadOptions();
        }

        private void SetContent(BaseUserControl content)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(content);
            content.Dock = DockStyle.Fill;
            content.Initialize();
        }
        //Com-порты
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetContent(_comPortListControl.Value);
        }
        //компрессоры
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowCompressors();
        }

        private void ShowCompressors()
        {
            SetContent(_controllerListControl.Value);
        }
        //настройки
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SetContent(_settingsControl.Value);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.SaveCompressors();
            Settings.Save();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
