using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Data.Index.CustomType;
using UmtData.Data.Settings;
using UmtData.Helpers;
using UniversalModbusTool.Core;
using UniversalModbusTool.Properties;

namespace UniversalModbusTool.Forms
{
    public partial class CompressorMenu : Form
    {
        private readonly CompressorSetting _compressorSetting;
        private Indexes Indexes => _compressorSetting.Indexes;
        private readonly List<TabPage> _tabPages = new List<TabPage>();
        private readonly List<Control> _changedControls = new List<Control>();
        private bool _stopEvent;
        private bool _stopListboxEvent;
        private int _lastListBox1SelectedIndex = -1;
        private TabPage _currentTabPage;
        private Thread _refreshThread;
        private const string RefreshButtonText = "Обновить";
        private const string WriteButtonText = "Записать";
        private bool _threadAborted = false;

        private Button[] ButtonsOnCurrentPage
        {
            get
            {
                return _currentTabPage?.Controls.Cast<object>().Where(control => control is Button).Cast<Button>().ToArray();
            }
        }

        private Button WriteButton
        {
            get
            {
                return _currentTabPage?.Controls.Cast<object>()
                    .Where(control => control is Button && ((Button)control).Text == WriteButtonText).Cast<Button>().FirstOrDefault();
            }
        }

        private Button RefreshButton
        {
            get
            {
                return _currentTabPage?.Controls.Cast<object>()
                    .Where(control => control is Button && ((Button)control).Text == RefreshButtonText).Cast<Button>().FirstOrDefault();
            }
        }

        public CompressorMenu(CompressorSetting setting)
        {
            InitializeComponent();
            _compressorSetting = setting;

            if (Indexes == null)
                return;
            InitializeListBox();
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void InitializeListBox()
        {
            if (Indexes.CoilStatuses.Count > 0)
            {
                listBox1.Items.Add(Resources.CoilStatus);
                MakeControls(MakeTabPage(Resources.CoilStatus, Resources.CoilStatus), Indexes.CoilStatuses);
            }
            if (Indexes.InputStatusGroups.Count > 0)
            {
                listBox1.Items.Add(Resources.InputStatus);
                foreach (var indexGroup in Indexes.InputStatusGroups.Where(indexGroup => indexGroup.Values.Count > 0))
                {
                    MakeControls(MakeTabPage(indexGroup.Name, Resources.InputStatus), indexGroup.Values);
                }
            }
            if (Indexes.InputRegisterGroups.Count > 0)
            {
                listBox1.Items.Add(Resources.InputRegister);
                foreach (var indexGroup in Indexes.InputRegisterGroups.Where(indexGroup => indexGroup.Values.Count > 0))
                {
                    MakeControls(MakeTabPage(indexGroup.Name, Resources.InputRegister), indexGroup.Values);
                }
            }
            if (Indexes.HoldRegisterGroups.Count > 0)
            {
                listBox1.Items.Add(Resources.HoldRegister);
                foreach (var indexGroup in Indexes.HoldRegisterGroups.Where(indexGroup => indexGroup.Values.Count > 0))
                {
                    MakeControls(MakeTabPage(indexGroup.Name, Resources.HoldRegister), indexGroup.Values);
                }
            }
        }

        private TabPage MakeTabPage(string name, string groupName)
        {
            var p = new TabPage(name)
            {
                AutoScroll = true,
                UseVisualStyleBackColor = true,
                Tag = groupName,
            };
            _tabPages.Add(p);
            return p;
        }

        private void StartRefreshIndexes()
        {
            if (!CheckSaving())
                return;

            if (_currentTabPage != null)
                _currentTabPage.Enabled = false;

            if (_refreshThread != null)
            {
                _threadAborted = true;
                return;
            }

            //_refreshThread?.Abort();
            _refreshThread = new Thread(RefreshIndexes);
            _refreshThread.Start();
        }

        private void RefreshIndexes()
        {
            if (_currentTabPage == null)
            {
                _refreshThread = null;
                return;
            }

            var buttons = ButtonsOnCurrentPage;
            if (buttons != null)
                Invoke(() =>
                {
                    foreach (var button in buttons)
                    {
                        button.Enabled = false;
                    }
                });
            Invoke(() => _currentTabPage.Enabled = false);

            var isError = false;
            _stopEvent = true;
            Invoke(() => ErrorTextBox.Text = $"{DateTimeHelper.GetNowTime()} Чтение регистров \"{_currentTabPage.Text}\"");
            
            foreach (var c in _currentTabPage.Controls)
            {
                var control = c as Control;
                var baseIndex = control?.Tag as BaseIndex;
                if (baseIndex != null)
                {
                    try
                    {
                        if (_threadAborted)
                        {
                            _threadAborted = false;
                            _refreshThread = null;
                            Invoke(StartRefreshIndexes);
                            return;
                        }

                        var x = ModbusTool.Read(baseIndex, _compressorSetting);

                        if (_threadAborted)
                        {
                            _threadAborted = false;
                            _refreshThread = null;
                            Invoke(StartRefreshIndexes);
                            return;
                        }

                        if (c is CheckBox)
                        {
                            Invoke(() => ((CheckBox) c).Checked = x == 1);
                        }
                        else if (c is TextBox)
                        {
                            Invoke(() => ((TextBox) c).Text = x.ToString());
                        }
                        else if (c is NumericUpDown)
                        {
                            Invoke(() =>
                            {
                                ((NumericUpDown) c).Value = x;
                                ValidateRegister((NumericUpDown) c);
                            });
                            /*
                            catch (Exception ex)
                            {
                                isError = true;
                                Invoke(() => ExceptionHelper.ShowException(ErrorTextBox, ex, true,
                                    $"{DateTimeHelper.GetNowTime()} Ошибка чтения регистра {baseIndex.Address} с функцией {baseIndex.Function}, значение {x} не входит в заданные рамки [{((NumericUpDown) c).Minimum} - {((NumericUpDown) c).Maximum}]"));
                            }
                            */
                        }
                        else if (c is ComboBox)
                        {
                            var source = ((ComboBox) c).DataSource as List<CustomValue>;
                            Invoke(() => ((ComboBox) c).SelectedValue = x);
                            if (source != null)
                                Invoke(() => ((ComboBox) c).SelectedItem = source.FirstOrDefault(u => u.Value == x));
                        }
                        else
                        {
                            Invoke(() => control.Text = x.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        Invoke(() => ExceptionHelper.ShowException(ErrorTextBox, ex, true,
                            $"{DateTimeHelper.GetNowTime()} Ошибка чтения регистра {baseIndex.Address} с функцией {baseIndex.Function}"));
                    }
                }
            }
            _stopEvent = false;
            if (!isError)
                Invoke(() => ErrorTextBox.AppendText($"\r\n{DateTimeHelper.GetNowTime()} Все регистры \"{_currentTabPage.Text}\" прочитаны без ошибок"));

            var rButton = RefreshButton;
            if (rButton != null)
            {
                Invoke(() => rButton.Enabled = true);
            }
            Invoke(() => _currentTabPage.Enabled = true);
            /*
            if (buttons != null)
                Invoke(() =>
                {
                    foreach (var button in buttons)
                    {
                        button.Enabled = true;
                    }
                });
                */
            _refreshThread = null;
        }

        private void MakeControls(TabPage page, IEnumerable<BaseIndex> list)
        {
            var p = new Point(6, 13);
            var q = new Point();
            var t = new Point();
            var tab = 1;

            var controls = new List<Tuple<Label, Control, Label>>();

            var makeRefreshButton = false;
            var makeWriteButton = false;

            foreach (var index in list)
            {
                var label = new Label()
                {
                    AutoSize = true,
                    Text = index.Function,
                    Location = p
                };
                q.X = p.X + 250;
                q.Y = p.Y - 2;
                t.X = q.X;
                t.Y = p.Y - 1;

                Control control = null;
                var register = index as BaseRegister;
                if (register != null && register.CustomType != 0)
                {
                    var x = Indexes.CustomTypes.FirstOrDefault(u => u.Id == register.CustomType);
                    if (x != null)
                        control = new ComboBox()
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            DisplayMember = "Description",
                            ValueMember = "Value",
                            DataSource = new List<CustomValue>(x.Values),
                            TabIndex = tab++,
                            FormattingEnabled = true,
                            Size = new Size(120, 21),
                            Location = q, 
                            Tag = register
                        };
                }

                if (control == null)
                {
                    var min = register?.Min;
                    var max = register?.Max;
                    if (register != null)
                    {
                        if (index.IsReadOnly)
                        {
                            control = new TextBox()
                            {
                                Location = q,
                                TabIndex = tab++,
                                Size = new Size(80, 20),
                                Tag = index,
                                ReadOnly = index.IsReadOnly
                            };
                        }
                        else
                            control = new NumericUpDown()
                        {
                            Location = q,
                            TabIndex = tab++,
                            Size = new Size(80, 20),
                            Tag = index,
                            ReadOnly = index.IsReadOnly,
                            Increment = index.IsReadOnly ? 0 : 1,
                            Minimum = Int32.MinValue,
                            Maximum = Int32.MaxValue
                        };
                    }
                    else
                        control = new CheckBox()
                        {
                            Location = p,
                            TabIndex = tab++,
                            Size = new Size(300, 20),
                            Tag = index,
                            Text = index.Function,
                            AutoCheck = !index.IsReadOnly,
                        };
                }

                Label unitsLabel = null;
                if (!string.IsNullOrWhiteSpace(register?.Units))
                {
                    unitsLabel = new Label()
                    {
                        AutoSize = true,
                        Text = register.Units,
                        Location = new Point(q.X + control.Width + 3, p.Y)
                    };
                    
                }

                if (control is CheckBox)
                {
                    label = null;
                }
                controls.Add(new Tuple<Label, Control, Label>(label, control, unitsLabel));

                p.Y += 22;

                makeWriteButton = index is CoilStatus || index is HoldRegister;
                makeRefreshButton = true;
            }

            if (makeRefreshButton)
            {
                var b = new Button
                {
                    Text = RefreshButtonText,
                    Location = p,
                    AutoSize = true
                };
                b.Click += (sender, args) => StartRefreshIndexes();
                page.Controls.Add(b);
                
                if (makeWriteButton)
                {
                    var w = new Button()
                    {
                        Text = WriteButtonText,
                        Location = new Point(p.X + b.Width + 5, p.Y),
                        AutoSize = true
                    };
                    w.Click += (sender, args) => WriteIndexes();
                    page.Controls.Add(w);
                }
            }

            var maxWidth = 0;
            foreach (var tuple in controls)
            {
                if (tuple.Item1 != null)
                {
                    page.Controls.Add(tuple.Item1);
                    if (tuple.Item1.Width > maxWidth)
                        maxWidth = tuple.Item1.Width;
                }
            }
            foreach (var tuple in controls)
            {
                if (tuple.Item2 != null)
                {
                    //30 - это место для иконки ошибки
                    tuple.Item2.Location = new Point(maxWidth > 0? maxWidth + 28 : 10, tuple.Item2.Location.Y);
                    if (tuple.Item3 != null)
                    {
                        tuple.Item3.Location = new Point(tuple.Item2.Location.X + tuple.Item2.Width + 3, 
                            tuple.Item3.Location.Y);
                        page.Controls.Add(tuple.Item3);
                    }
                    page.Controls.Add(tuple.Item2);

                    if (makeWriteButton)
                    {
                        var c = tuple.Item2;
                        if (c is NumericUpDown)
                        {
                            ((NumericUpDown) c).ValueChanged += Control_ValueChanged;
                        }
                        else if (c is CheckBox)
                        {
                            ((CheckBox) c).CheckedChanged += Control_ValueChanged;
                        }
                        else if (c is ComboBox)
                            ((ComboBox)c).SelectedValueChanged += Control_ValueChanged;
                    }
                }
            }
        }

        private bool CheckSaving()
        {
            if (_changedControls.Count > 0)
            {
                var result = MessageBox.Show("Есть несохраненные изменения. Сохранить?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.Yes)
                    WriteIndexes();
                else if (result == DialogResult.No)
                    ClearChangedControls();
            }
            return true;
        }

        private void ClearChangedControls()
        {
            _changedControls.Clear();
            var button = WriteButton;
            if (button != null)
                button.Enabled = false;
        }

        private void WriteIndexes()
        {
            if (_currentTabPage == null)
                return;

            ErrorTextBox.Text = string.Empty;
            var isError = false;
            var was = false;
            if (_changedControls.Count > 0)
            {
                was = true;

                foreach (var c in _changedControls)
                {
                    var baseIndex = c.Tag as BaseIndex;
                    var v = 0m;
                    if (baseIndex != null)
                    {
                        try
                        {
                            //todo проверка перед сейвом
                            if (c is NumericUpDown)
                                v = ((NumericUpDown) c).Value;
                            else if (c is ComboBox)
                                v = Convert.ToDecimal(((ComboBox)c).SelectedValue);
                            else if (c is CheckBox)
                                v = ((CheckBox) c).Checked ? 1 : 0;

                            ModbusTool.Write(baseIndex, _compressorSetting, v);
                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            ExceptionHelper.ShowException(ErrorTextBox, ex, true,
                                $"{DateTimeHelper.GetNowTime()} Ошибка записи регистра {baseIndex.Address} с функцией {baseIndex.Function} и значением {v}");
                        }
                    }
                }
                ClearChangedControls();
            }

            if (!was)
                ErrorTextBox.Text = $"{DateTimeHelper.GetNowTime()} Вы не изменили ни один из регистров \"{_currentTabPage.Text}\"";
            else if (!isError)
                ErrorTextBox.Text = $"{DateTimeHelper.GetNowTime()} Все измененные регистры \"{_currentTabPage.Text}\" записаны без ошибок";
        }

        private void ValidateRegister(NumericUpDown n)
        {
            var baseRegister = n.Tag as BaseRegister;
            var s = new StringBuilder();
            if (baseRegister != null)
            {
                if (baseRegister.Min.HasValue && n.Value < baseRegister.Min.Value)
                    s.AppendLine($"Значение регистра должно быть не меньше {baseRegister.Min.Value}");
                if (baseRegister.Max.HasValue && n.Value > baseRegister.Max.Value)
                    s.AppendLine($"Значение регистра должно быть не больше {baseRegister.Max.Value}");
            }
            var result = s.ToString();
            ErrorProvider.SetIconAlignment(n, ErrorIconAlignment.MiddleLeft);
            ErrorProvider.SetError(n, string.IsNullOrWhiteSpace(result) ? null : result);
        }

        #region Events

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (_stopEvent)
                return;
            var c = sender as Control;
            if (c != null && !_changedControls.Contains(c))
                _changedControls.Add(c);

            var n = sender as NumericUpDown;
            if (n != null)
                ValidateRegister(n);

            var button = WriteButton;
            if (button != null)
                button.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_stopListboxEvent)
                return;

            if (!CheckSaving())
            {
                _stopListboxEvent = true;
                listBox1.SelectedIndex = _lastListBox1SelectedIndex;
                _stopListboxEvent = false;
                return;
            }

            tabControl1.TabPages.Clear();
            ClearChangedControls();
            _lastListBox1SelectedIndex = listBox1.SelectedIndex;
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var key = item.ToString();
                var first = true;
                foreach (var p in _tabPages)
                {
                    if (key.Equals(p.Tag) &&
                        !tabControl1.TabPages.Contains(p))
                    {
                        tabControl1.TabPages.Add(p);
                        if (first)
                        {
                            _currentTabPage = p;
                            first = false;
                        }
                    }
                }
                if (!first)
                    StartRefreshIndexes();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            _currentTabPage = e.TabPage;
            StartRefreshIndexes();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !CheckSaving();
        }

        #endregion

        protected void Invoke(Action action)
        {
            if (!IsHandleCreated)
                return;

            if (InvokeRequired)
                base.Invoke(action);
            else
                action();
        }
    }
}
