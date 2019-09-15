using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UmtData.Data;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Data.Index.CustomType;
using UmtData.Helpers;
using UmtExcelImport.Properties;
using Excel = Microsoft.Office.Interop.Excel;

namespace UmtExcelImport
{
    public partial class UmtEditorForm : Form
    {
        private Indexes Indexes
        {
            get { return bindingSource1.DataSource as Indexes; }
            set
            {
                if (Indexes != value)
                {
                    if (Indexes != null)
                    {
                        (Indexes as INotifyPropertyChanged).PropertyChanged -= OnIndexesPropertyChanged;
                    }
                    bindingSource1.DataSource = value;
                    if (value != null)
                    {
                        (value as INotifyPropertyChanged).PropertyChanged -= OnIndexesPropertyChanged;
                        (value as INotifyPropertyChanged).PropertyChanged += OnIndexesPropertyChanged;
                        SaveAsToolStripMenuItem.Enabled = true;
                        SaveToolStripMenuItem.Enabled = true;

                        if (value.CustomTypes.Count(u => u.Id == 0) == 0)
                        {
                            value.InsertDefaultCustomType();
                        }
                        _baseRegisterEditor.Value.CustomTypes = value.CustomTypes;
                    }
                    else
                    {
                        SaveAsToolStripMenuItem.Enabled = false;
                        SaveToolStripMenuItem.Enabled = false;
                    }
                    BuildTree();
                }
            }
        }

        private TreeNode _currentNode;
        private string _searchString;
        private readonly IList<TreeNode> _foundNodes = new List<TreeNode>();
        private bool _hasChanges;
        private string _protocolFileName;
        private IList<DataType> _dataTypes = Enum.GetValues(typeof(DataType)).Cast<DataType>().ToList();

        private readonly Lazy<BaseIndexEditor> _baseIndexEditor = new Lazy<BaseIndexEditor>(() => new BaseIndexEditor());
        private readonly Lazy<BaseRegisterEditor> _baseRegisterEditor = new Lazy<BaseRegisterEditor>(() => new BaseRegisterEditor());
        private readonly Lazy<CustomTypeEditor> _customTypeEditor = new Lazy<CustomTypeEditor>(() => new CustomTypeEditor());

        public UmtEditorForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = string.Empty;
            toolStripProgressBar1.Visible = false;
            AddToolStripButton.Enabled = false;
            DeleteToolStripButton.Enabled = false;
            SaveAsToolStripMenuItem.Enabled = false;
            SaveToolStripMenuItem.Enabled = false;
        }

        private void OnIndexesPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            _hasChanges = true;
        }

        #region Импорт из excel

        private void ImportProtocolFromExcel_Click(object sender, EventArgs e)
        {
            if (!CheckSavingChanges())
                return;

            using (var openFileDialog1 = new OpenFileDialog
            {
                Filter = "Книги Excel (97-2003)|*.xls|Книги Excel|*.xlsx|Все файлы|*.*",
                FilterIndex = 2,
                Title = "Открыть файл Excel для импорта протокола"
            })
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            if (ImportFromExcel(openFileDialog1.FileName))
                            {
                                _hasChanges = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.ShowException(ex);
                    }
                }
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                ExceptionHelper.ShowException(ex, "Unable to release the Object");
                //MessageBox.Show("Unable to release the Object " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        
        private bool ImportFromExcel(string fileName)
        {
            var result = false;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Range range;
            Excel.Worksheet xlWorkSheet;

            string str;
            var rCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

            range = xlWorkSheet.UsedRange;

            toolStripStatusLabel1.Text = "Обработано";
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = range.Rows.Count;

            var currentType = IndexType.None;
            var indexes = new Indexes()
            {
                Name = Path.GetFileNameWithoutExtension(fileName)
            };

            try
            {
                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    str = GetValueFromCell(range, rCnt, 1);

                    if (string.IsNullOrWhiteSpace(str))
                        continue;

                    var lower = str.ToLower();
                    var second = GetValueFromCell(range, rCnt, 2);

                    if (string.IsNullOrWhiteSpace(second))
                    {
                        //название таблицы
                        if (lower.Contains("coil status"))
                            currentType = IndexType.CoilStatus;
                        else if (lower.Contains("input status"))
                        {
                            currentType = IndexType.InputStatus;

                            var s = str.Split('-');
                            if (s.Length == 2)
                            {
                                indexes.InputStatusGroups.Add(new IndexGroup<InputStatus>()
                                {
                                    Name = s[1].Trim()
                                });
                            }
                        }
                        else if (lower.Contains("input register"))
                        {
                            currentType = IndexType.InputRegister;

                            var s = str.Split('-');
                            if (s.Length == 2)
                            {
                                indexes.InputRegisterGroups.Add(new IndexGroup<InputRegister>()
                                {
                                    Name = s[1].Trim()
                                });
                            }
                        }
                        else if (lower.Contains("hold register"))
                        {
                            currentType = IndexType.HoldRegister;

                            var s = str.Split('-');
                            if (s.Length == 2)
                            {
                                indexes.HoldRegisterGroups.Add(new IndexGroup<HoldRegister>()
                                {
                                    Name = s[1].Trim()
                                });
                            }
                        }
                    }
                    else
                    {
                        //начало таблицы или пустая функция
                        if (lower == "address" || string.IsNullOrWhiteSpace(second) || second.Trim() == "-")
                        {
                            continue;
                        }
                        str = Regex.Replace(str, @"\s+", "");
                        ushort address;
                        if (ushort.TryParse(str, out address))
                        {
                            switch (currentType)
                            {
                                case IndexType.CoilStatus:
                                    indexes.CoilStatuses.Add(new CoilStatus()
                                    {
                                        Address = address,
                                        Function = second,
                                        IsReadOnly = GetValueFromCell(range, rCnt, 5).ToLower().Contains("read"),
                                        DataType = GetTypeFromString(GetValueFromCell(range, rCnt, 3), currentType),
                                    });
                                    break;

                                case IndexType.InputStatus:
                                    indexes.InputStatusGroups.Last().Values.Add(new InputStatus()
                                    {
                                        Address = address,
                                        Function = second,
                                        DataType = GetTypeFromString(GetValueFromCell(range, rCnt, 3), currentType),
                                    });
                                    break;

                                case IndexType.InputRegister:
                                    var sixth = GetMinMaxFromString(GetValueFromCell(range, rCnt, 6));
                                    indexes.InputRegisterGroups.Last().Values.Add(new InputRegister()
                                    {
                                        Address = address,
                                        Function = second,
                                        Units = GetUnitsFromString(GetValueFromCell(range, rCnt, 3)),
                                        DataType = GetTypeFromString(GetValueFromCell(range, rCnt, 5), currentType),
                                        Multiplier = GetMultiplierFromString(GetValueFromCell(range, rCnt, 7)),
                                        Min = sixth.Item1,
                                        Max = sixth.Item2
                                    });
                                    break;
                                case IndexType.HoldRegister:
                                    var sixth2 = GetMinMaxFromString(GetValueFromCell(range, rCnt, 6));
                                    indexes.HoldRegisterGroups.Last().Values.Add(new HoldRegister()
                                    {
                                        Address = address,
                                        Function = second,
                                        Units = GetUnitsFromString(GetValueFromCell(range, rCnt, 3)),
                                        DataType = GetTypeFromString(GetValueFromCell(range, rCnt, 5), currentType),
                                        Multiplier = GetMultiplierFromString(GetValueFromCell(range, rCnt, 7)),
                                        Min = sixth2.Item1,
                                        Max = sixth2.Item2,
                                        IsReadOnly = GetValueFromCell(range, rCnt, 8) == "R"
                                    });
                                    break;
                            }

                        }
                    }
                    toolStripProgressBar1.Value = rCnt;
                }
                Indexes = indexes;
                _protocolFileName = string.Empty;
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowException(ex, $"Ошибка на {rCnt} строке");
                toolStripStatusLabel1.Text = $"Ошибка при импорте из {fileName}";
                toolStripProgressBar1.Visible = false;
            }
            finally
            {
                if (result)
                {
                    toolStripStatusLabel1.Text = $"Импорт из {fileName} успешен";
                    toolStripProgressBar1.Visible = false;
                }
                xlWorkBook.Close(true);
                xlApp.Quit();

                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return result;
        }

        private string GetValueFromCell(Excel.Range range, int row, int column)
        {
            var r = range?.Cells[row, column] as Excel.Range;
            if (r != null)
            {
                if (r.MergeCells)
                {
                    var area = r.MergeArea;
                    
                    return (string)area?.Value2[1,1] ?? string.Empty;
                }

                return (string) r.Value2 ?? string.Empty;
            }

            return string.Empty;
        }

        private string GetUnitsFromString(string s)
        {
            return string.IsNullOrWhiteSpace(s) || s == "-" ? string.Empty : s;
        }

        private DataType GetTypeFromString(string s, IndexType indexType)
        {
            if (string.IsNullOrWhiteSpace(s))
                return DataType.Int16;
            s = s.Trim();
            Func<DataType, bool> func = u => string.Equals(u.ToString(), s, StringComparison.InvariantCultureIgnoreCase);
            if (_dataTypes.Any(func))
                return _dataTypes.First(func);
            if (indexType == IndexType.CoilStatus || indexType == IndexType.InputStatus)
                return DataType.Digital;
            return DataType.Int16;
        }

        private int GetMultiplierFromString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 1;
            var lower = s.Trim().ToLower();
            lower = Regex.Replace(lower, @"[x]", "");
            lower = Regex.Replace(lower, @"\s+", "");
            int result;
            if (Int32.TryParse(lower, out result))
                return result;
            return 1;
        }

        private Tuple<decimal?, decimal?> GetMinMaxFromString(string s)
        {
            var def = new Tuple<decimal?, decimal?>(null, null);
            if (string.IsNullOrWhiteSpace(s))
                return def;

            var values = s.Split('~');
            if (values.Length == 2)
            {
                decimal result;
                var min = (Decimal.TryParse(values[0], out result) ? (decimal?)result : null) ??
                          (Decimal.TryParse(Regex.Replace(values[0], @"[.]", ","), out result) ? (decimal?)result : null);

                var values2 = values[1].Trim().Split(' ');
                var max = (Decimal.TryParse(values[1], out result) ? (decimal?)result : null) ??
                          (Decimal.TryParse(values2[0], out result) ? (decimal?)result : null) ??
                          (Decimal.TryParse(Regex.Replace(values2[0], @"[.]", ","), out result) ? (decimal?)result : null);

                return new Tuple<decimal?, decimal?>(min, max);
            }

            return def;
        }

        #endregion

        #region Дерево

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _currentNode = e.Node;
            panel1.Controls.Clear();
            
            if (e.Node.Tag != null)
            {
                DeleteToolStripButton.Enabled = true;

                var index = e.Node.Tag as BaseIndex;
                var register = index as BaseRegister;
                if (register != null)
                {
                    AddToolStripButton.Enabled = false;
                    //_baseRegisterEditor.Value.CustomTypes = GenerateCustomTypesList();
                    _baseRegisterEditor.Value.BaseRegister = register;
                    panel1.Controls.Add(_baseRegisterEditor.Value);

                    var o = register as INotifyPropertyChanged;
                    if (o != null)
                    {
                        o.PropertyChanged -= BaseIndexPropertyChanged;
                        o.PropertyChanged += BaseIndexPropertyChanged;
                    }
                }
                else if (index != null)
                {
                    AddToolStripButton.Enabled = false;
                    _baseIndexEditor.Value.BaseIndex = index;
                    panel1.Controls.Add(_baseIndexEditor.Value);

                    var o = index as INotifyPropertyChanged;
                    if (o != null)
                    {
                        o.PropertyChanged -= BaseIndexPropertyChanged;
                        o.PropertyChanged += BaseIndexPropertyChanged;
                    }
                }
                else
                {
                    var customType = e.Node.Tag as CustomType;
                    if (customType != null)
                    {
                        AddToolStripButton.Enabled = false;
                        _customTypeEditor.Value.CustomType = customType;
                        panel1.Controls.Add(_customTypeEditor.Value);
                        
                        var o = (INotifyPropertyChanged) customType;
                        o.PropertyChanged -= CustomType_PropertyChanged;
                        o.PropertyChanged += CustomType_PropertyChanged;
                    }
                    else
                    {
                        //группа
                        AddToolStripButton.Enabled = true;
                    }
                }
            }
            

            if (e.Node.Parent == null)
            {
                AddToolStripButton.Enabled = true;
                DeleteToolStripButton.Enabled = false;
            }
        }

        private void CustomType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CustomType.Name))
            {
                var type = sender as CustomType;
                if (type != null)
                    _currentNode.Text = type.Name;
            }
            _hasChanges = true;
        }

        private void BaseIndexPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BaseIndex.Function))
            {
                var baseIndex = sender as BaseIndex;
                if (baseIndex != null)
                    _currentNode.Text = baseIndex.Function;
            }
            _hasChanges = true;
        }
        
        private void BuildTree()
        {
            var coilStatusNode = new TreeNode()
            {
                Text = Resources.UmtEditorForm_BuildTree_Coil_Status
            };
            var inputStatusNode = new TreeNode()
            {
                Text = Resources.UmtEditorForm_BuildTree_Input_Status
            };
            var inputRegisterNode = new TreeNode()
            {
                Text = Resources.UmtEditorForm_BuildTree_Input_Register
            };
            var holdRegisterNode = new TreeNode()
            {
                Text = Resources.UmtEditorForm_BuildTree_Hold_Register
            };
            var customTypeNode = new TreeNode()
            {
                Text = Resources.UmtEditorForm_BuildTree_Custom_types
            };
            foreach (var coilStatus in Indexes.CoilStatuses)
            {
                coilStatusNode.Nodes.Add(new TreeNode()
                {
                    Text = coilStatus.Function,
                    Tag = coilStatus
                });
            }

            foreach (var group in Indexes.InputStatusGroups)
            {
                var node = new TreeNode(group.Name);
                node.Tag = group;
                foreach (var index in group.Values)
                {
                    node.Nodes.Add(new TreeNode()
                    {
                        Text = index.Function,
                        Tag = index
                    });
                }
                inputStatusNode.Nodes.Add(node);
            }

            foreach (var group in Indexes.InputRegisterGroups)
            {
                var node = new TreeNode(group.Name);
                node.Tag = group;
                foreach (var index in group.Values)
                {
                    node.Nodes.Add(new TreeNode()
                    {
                        Text = index.Function,
                        Tag = index
                    });
                }
                inputRegisterNode.Nodes.Add(node);
            }

            foreach (var group in Indexes.HoldRegisterGroups)
            {
                var node = new TreeNode(group.Name);
                node.Tag = group;
                foreach (var index in group.Values)
                {
                    node.Nodes.Add(new TreeNode()
                    {
                        Text = index.Function,
                        Tag = index
                    });
                }
                holdRegisterNode.Nodes.Add(node);
            }

            foreach (var type in Indexes.CustomTypes.Where(u => u.Id > 0))
            {
                customTypeNode.Nodes.Add(new TreeNode()
                {
                    Text = type.Name,
                    Tag = type
                });
            }
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(coilStatusNode);
            treeView1.Nodes.Add(inputStatusNode);
            treeView1.Nodes.Add(inputRegisterNode);
            treeView1.Nodes.Add(holdRegisterNode);
            treeView1.Nodes.Add(customTypeNode);
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null) return;

            // if treeview's HideSelection property is "True", 
            // this will always returns "False" on unfocused treeview
            var selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var unfocused = !e.Node.TreeView.Focused;

            // we need to do owner drawing only on a selected node
            // and when the treeview is unfocused, else let the OS do it for us
            if (selected && unfocused)
            {
                var font = e.Node.NodeFont ?? e.Node.TreeView.Font;
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        #endregion

        #region Сохранение / Загрузка

        private bool CheckSavingChanges()
        {
            if (!_hasChanges)
                return true;

            if (_hasChanges)
            {
                var result = MessageBox.Show("Сохранить изменения?", "Вопрос", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel)
                    return false;

                if (result == DialogResult.Yes)
                {
                    SaveXmlProtocolFile(_protocolFileName);
                    //если сохранение не удалось
                    if (_hasChanges)
                        return false;
                }
            }
            return true;
        }

        private void SaveXmlProtocol_Click(object sender, EventArgs e)
        {
            SaveXmlProtocolFile(_protocolFileName);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveXmlProtocolFile();
        }

        private void SaveXmlProtocolFile(string fileName = null)
        {
            if (!ValidateIndexes())
                return;

            if (_currentNode?.Tag is CustomType)
            {
                _customTypeEditor.Value.UpdateGrid();
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                using (var dlg = new SaveFileDialog()
                {
                    Filter = "XML файлы|*.xml|Все файлы|*.*",
                    Title = "Сохранить протокол работы с компрессором",
                    FileName = Indexes.Name
                    //FilterIndex = 2
                })
                {
                    if (dlg.ShowDialog() == DialogResult.OK &&
                        !string.IsNullOrWhiteSpace(dlg.FileName))
                    {
                        fileName = dlg.FileName;
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                if (XmlSaver<Indexes>.Save(Indexes, fileName))
                {
                    _hasChanges = false;
                    _protocolFileName = fileName;
                    toolStripStatusLabel1.Text = $"{fileName} успешно сохранен";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Ошибка при сохранении протокола";
                }
            }
        }

        private void OpenXmlProtocol_Click(object sender, EventArgs e)
        {
            if (!CheckSavingChanges())
                return;

            using (var openFileDialog1 = new OpenFileDialog
            {
                Filter = "XML файлы|*.xml|Все файлы|*.*",
                Title = "Открыть протокол работы с компрессором"
            })
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(openFileDialog1.FileName))
                        {
                            var result = XmlSaver<Indexes>.Load(openFileDialog1.FileName);
                            if (result != null)
                            {
                                Indexes = result;
                                _protocolFileName = openFileDialog1.FileName;
                                toolStripStatusLabel1.Text = $"{openFileDialog1.FileName} успешно загружен";
                            }
                            else
                            {
                                toolStripStatusLabel1.Text = "Ошибка при открытии протокола";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.ShowException(ex);
                        toolStripStatusLabel1.Text = "Ошибка при открытии протокола";
                    }
                }
            }
        }

        private void UmtEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CheckSavingChanges();
        }

        private bool ValidateIndexes()
        {
            var failed = false;
            var dubles = new List<BaseIndex>();
            var specialFunction = SpecialFunction.None;
            Indexes.SpecialFunctions.Clear();
            foreach (var func in Enum.GetValues(typeof(SpecialFunction)).Cast<SpecialFunction>()
                .Where(u => u != SpecialFunction.None && u != SpecialFunction.NotSelected))
            {
                var list = treeView1.Nodes.OfType<TreeNode>().ToList();
                var count = 0;
                dubles.Clear();
                while (list.Count > 0)
                {
                    var node = list[0];

                    var baseIndex = node.Tag as BaseIndex;
                    //if ((node.Tag as BaseIndex)?.SpecialFunction == func)
                    if (baseIndex != null && baseIndex.SpecialFunction.HasFlag(func))
                    {
                        count++;
                        dubles.Add((BaseIndex)node.Tag);
                        if (count > 1)
                        {
                            failed = true;
                        }
                        else
                        {
                            Indexes.SpecialFunctions.Add(new SpecialFunctionIndex(func, (BaseIndex)node.Tag));
                        }
                    }

                    list.Remove(node);
                    list.AddRange(node.Nodes.OfType<TreeNode>());
                }

                if (failed)
                {
                    specialFunction = func;
                    break;
                }
            }

            if (failed)
            {
                var s = new StringBuilder();
                foreach (var duble in dubles)
                {
                    s.AppendLine(duble.Address + ": " + duble.Function);
                }

                MessageBox.Show($"Обнаружены дубликаты назначения \"{specialFunction.GetDescription()}\": \n{s}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return !failed;
        }

        #endregion

        #region Панель инструментов

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
                return;
            _hasChanges = true;
            if (_currentNode.Parent == null)
            {
                //добавляем в верхние узлы
                if (_currentNode.Text == Resources.UmtEditorForm_BuildTree_Coil_Status)
                {
                    var x = new CoilStatus()
                    {
                        Function = Resources.UmtEditorForm_New_Element
                    };
                    Indexes.CoilStatuses.Add(x);

                    _currentNode.Nodes.Add(new TreeNode()
                    {
                        Text = Resources.UmtEditorForm_New_Element,
                        Tag = x
                    });
                }
                else if (_currentNode.Text == Resources.UmtEditorForm_BuildTree_Input_Status)
                {
                    var x = new IndexGroup<InputStatus>()
                    {
                        Name = Resources.UmtEditorForm_New_Element
                    };
                    Indexes.InputStatusGroups.Add(x);

                    _currentNode.Nodes.Add(new TreeNode()
                    {
                        Text = Resources.UmtEditorForm_New_Element,
                        Tag = x
                    });
                }
                else if (_currentNode.Text == Resources.UmtEditorForm_BuildTree_Input_Register)
                {
                    var x = new IndexGroup<InputRegister>()
                    {
                        Name = Resources.UmtEditorForm_New_Element
                    };
                    Indexes.InputRegisterGroups.Add(x);

                    _currentNode.Nodes.Add(new TreeNode()
                    {
                        Text = Resources.UmtEditorForm_New_Element,
                        Tag = x
                    });
                }
                else if (_currentNode.Text == Resources.UmtEditorForm_BuildTree_Hold_Register)
                {
                    var x = new IndexGroup<HoldRegister>()
                    {
                        Name = Resources.UmtEditorForm_New_Element
                    };
                    Indexes.HoldRegisterGroups.Add(x);

                    _currentNode.Nodes.Add(new TreeNode()
                    {
                        Text = Resources.UmtEditorForm_New_Element,
                        Tag = x
                    });
                }
                else if (_currentNode.Text == Resources.UmtEditorForm_BuildTree_Custom_types)
                {
                    var t = new CustomType()
                    {
                        Name = Resources.UmtEditorForm_New_Element
                    };
                    Indexes.CustomTypes.Add(t);

                    _currentNode.Nodes.Add(new TreeNode()
                    {
                        Text = Resources.UmtEditorForm_New_Element,
                        Tag = t
                    });
                }
            }
            else
            {
                //добавляем в группу
                var group = _currentNode.Tag;
                if (group != null)
                {
                    var type = group.GetType();
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IndexGroup<>))
                    {
                        var newElement = Activator.CreateInstance(type.GetGenericArguments()[0]) as BaseIndex;
                        if (newElement != null)
                        {
                            newElement.Function = Resources.UmtEditorForm_New_Element;
                            (group as IList)?.Add(newElement);
                            _currentNode.Nodes.Add(new TreeNode()
                            {
                                Text = Resources.UmtEditorForm_New_Element,
                                Tag = newElement
                            });
                        }
                    }
                }
            }

            _currentNode.Expand();
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
                return;
            _hasChanges = true;
            if (_currentNode.Tag is CustomType)
            {
                var customType = _currentNode.Tag as CustomType;
                Indexes.CustomTypes.Remove(customType);

                //Очищаем особый тип данных
                foreach (var register in from @group in Indexes.InputRegisterGroups from register in @group.Values where register.CustomType == customType.Id select register)
                {
                    register.CustomType = 0;
                }
                foreach (var register in from @group in Indexes.HoldRegisterGroups from register in @group.Values where register.CustomType == customType.Id select register)
                {
                    register.CustomType = 0;
                }
            }
            else if (_currentNode.Tag is CoilStatus)
            {
                Indexes.CoilStatuses.Remove((CoilStatus) _currentNode.Tag);
            }
            else if (_currentNode.Tag is IndexGroup<InputStatus>)
            {
                Indexes.InputStatusGroups.Remove((IndexGroup<InputStatus>) _currentNode.Tag);
            }
            else if (_currentNode.Tag is IndexGroup<InputRegister>)
            {
                Indexes.InputRegisterGroups.Remove((IndexGroup<InputRegister>)_currentNode.Tag);
            }
            else if (_currentNode.Tag is IndexGroup<HoldRegister>)
            {
                Indexes.HoldRegisterGroups.Remove((IndexGroup<HoldRegister>)_currentNode.Tag);
            }
            else if (_currentNode.Tag is InputStatus)
            {
                var group = _currentNode.Parent?.Tag as IndexGroup<InputStatus>;
                group?.Values.Remove((InputStatus) _currentNode.Tag);
            }
            else if (_currentNode.Tag is InputRegister)
            {
                var group = _currentNode.Parent?.Tag as IndexGroup<InputRegister>;
                group?.Values.Remove((InputRegister)_currentNode.Tag);
            }
            else if (_currentNode.Tag is HoldRegister)
            {
                var group = _currentNode.Parent?.Tag as IndexGroup<HoldRegister>;
                group?.Values.Remove((HoldRegister)_currentNode.Tag);
            }

            _currentNode.Parent?.Nodes.Remove(_currentNode);
        }
        
        #endregion
        
        #region Поиск

        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Search();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var s = SearchTextBox.Text;
            if (string.IsNullOrWhiteSpace(s))
                return;
            s = s.Trim().ToLower();

            if (_searchString != s)
            {
                _foundNodes.Clear();
            }
            _searchString = s;
            
            var list = treeView1.Nodes.OfType<TreeNode>().ToList();
            var result = false;
            while (list.Count > 0)
            {
                var node = list[0];

                if (!_foundNodes.Contains(node) &&
                    (node.Text.ToLower().Contains(s) ||
                    (node.Tag as BaseIndex)?.Address.ToString().Contains(s) == true))
                {
                    treeView1.SelectedNode = node;
                    _foundNodes.Add(node);
                    result = true;
                    break;
                }

                list.Remove(node);
                list.AddRange(node.Nodes.OfType<TreeNode>());
            }
            if (!result)
            {
                //ничего не найдено
                if (_foundNodes.Count == 0)
                {
                    MessageBox.Show("Ничего не найдено", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var x = _foundNodes[0];
                    _foundNodes.Clear();
                    //_foundNodes.Add(x);
                    MessageBox.Show("Поиск достиг отправной точки", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    treeView1.SelectedNode = x;
                }
            }
        }

        #endregion
    }
}
