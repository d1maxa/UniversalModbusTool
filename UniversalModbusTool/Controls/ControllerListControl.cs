using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UmtData.Data;
using UmtData.Data.Settings;
using UmtData.Helpers;
using UniversalModbusTool.Core;
using UniversalModbusTool.Forms;
using UniversalModbusTool.Interface;

namespace UniversalModbusTool.Controls
{
    public partial class ControllerListControl : BaseUserControl, ICompressorListControl
    {
        private readonly TextBox _errorTextBox;

        public ControllerListControl(TextBox errorTextBox)
        {
            _errorTextBox = errorTextBox;
            InitializeComponent();
            InitMonitoringButton();
        }

        private void InitMonitoringButton()
        {
            if (Settings.IsMonitoring)
            {
                MonitoringToolStripButton.Text = "Остановить мониторинг";
                MonitoringToolStripButton.Image = Properties.Resources.stop;
            }
            else
            {
                MonitoringToolStripButton.Text = "Запустить мониторинг";
                MonitoringToolStripButton.Image = Properties.Resources.play;
            }
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddNewCompressor(new CompressorSetting(), true))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var c = dlg.CompressorSetting;
                    if (CheckExistingCompressor(c, true, null))
                        return;

                    Options.Compressors.Add(c);
                    Options.SaveCompressors();
                    flwContainer.Controls.Add(new CompressorItemControl(c, this));
                }
            }
        }

        private bool CheckExistingCompressor(CompressorSetting c, bool isNew, CompressorSetting existingCompressor)
        {
            if (Options.Compressors.Any(u => u.Address == c.Address && u.ComPortName == c.ComPortName && u != existingCompressor))
            {
                MessageBox.Show($"На панели уже присутствует интерфейс с адресом {c.ComPortName} ({c.Address})", isNew ? "Невозможно добавить новый компрессор" : "Невозможно отредактировать компрессор",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void ControllerListControl_Load(object sender, EventArgs e)
        {
            foreach (var compressor in Options.Compressors)
            {
                flwContainer.Controls.Add(new CompressorItemControl(compressor, this));
            }
            Timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Settings.IsMonitoring)
                return;

            foreach (var control in flwContainer.Controls)
            {
                var c = control as CompressorItemControl;
                if (c != null && c.RefreshThread == null)
                {
                    c.RefreshThread = new Thread(RefreshIndexesInItem);
                    c.RefreshThread.Start(c);
                }
            }
        }

        private void RefreshIndexesInItem(object control)
        {
            var c = control as CompressorItemControl;
            if (c == null)
                return;
            try
            {
                c.RefreshIndexes();
            }
            catch (Exception ex)
            {
                Invoke(() => ExceptionHelper.ShowException(_errorTextBox, ex, true,
                    $"{DateTimeHelper.GetNowTime()} Ошибка обновления компрессора {c.CompressorSetting} по адресу {c.CompressorSetting.ComPortName} ({c.CompressorSetting.Address})",
                    100000));
            }
            finally
            {
                c.RefreshThread = null;
            }
        }

        public void RemoveCompressor(CompressorItemControl control)
        {
            if (flwContainer.Controls.Contains(control))
            {
                flwContainer.Controls.Remove(control);
                if (Options.Compressors.Contains(control.CompressorSetting))
                {
                    Options.Compressors.Remove(control.CompressorSetting);
                    Options.SaveCompressors();
                }
            }
        }

        public void EditCompressor(CompressorItemControl control)
        {
            var editSetting = new CompressorSetting();
            editSetting.CopyFields(control.CompressorSetting);

            using (var dlg = new AddNewCompressor(editSetting, false))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var c = dlg.CompressorSetting;
                    if (CheckExistingCompressor(c, false, control.CompressorSetting))
                        return;

                    control.CompressorSetting.CopyFields(editSetting);
                    Options.SaveCompressors();
                }
            }
        }

        private void TemperatureToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new Graph(GraphType.Temperature))
            {
                dlg.ShowDialog();
            }
        }

        private void PressureToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new Graph(GraphType.Pressure))
            {
                dlg.ShowDialog();
            }
        }

        private void MonitoringToolStripButton_Click(object sender, EventArgs e)
        {
            Settings.IsMonitoring = Settings.IsMonitoring == false;
            InitMonitoringButton();
        }
    }
}
