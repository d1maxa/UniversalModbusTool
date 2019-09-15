using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UmtData.Data;
using UmtData.Data.Settings;
using UmtData.Helpers;

namespace UniversalModbusTool.Forms
{
    public partial class Graph : BaseForm
    {
        #region Vars

        private const string TemperatureText = "График температуры";
        private const string PressureText = "График давления";
        private const string EndPointsName = "_points";
        private readonly Font _titleFont = new Font(FontFamily.GenericSansSerif, 16);
        private readonly Color _titleColor = Color.DarkBlue;
        private readonly string _checked = Application.StartupPath + @"\Resources\chk_checked.bmp";
        private readonly string _unchecked = Application.StartupPath + @"\Resources\chk_unchecked.bmp";
        private const string TimeFormat = "dd.MM.yyyy HH:mm:ss";
        private int _numberOfComp;
        private int _numberOfValues;
        private int _interval;
        private DateTime _lastDateTime = DateTime.MinValue;

        private bool AutoRefresh
        {
            get { return _autoRefresh; }
            set
            {
                _autoRefresh = value;
                AutoRefreshToolStripButton.Text = _autoRefresh ? "Выключить автообновление" : "Включить автообновление";
            }
        }

        private readonly GraphType _graphType;
        private bool _autoRefresh;

        private string GraphText
        {
            get
            {
                if (_graphType == GraphType.Temperature)
                    return TemperatureText;
                return PressureText;
            }
        }

        #endregion

        private void Test()
        {
            var x = DateTime.Now.AddDays(-2);
            for (int i = 0; i < 3600*48; i++)
            {
                Options.Compressors[0].TemperatureValues.Add(new StatValue(x.AddSeconds(i), 13));
            }
        }

        public Graph(GraphType graphType)
        {
            Test();
            _graphType = graphType;
            InitializeComponent();

            AutoRefresh = Settings.GraphAutoRefresh;
            InitNumberOfValues(Settings.NumberOfValuesOnGraph);
            InitInterval(Settings.Interval);

            Init();

            SetChartDefaultSettings();

            InitPoints(Settings.IsPoints);
            InitValues(Settings.IsValues);
        }

        private void SetChartDefaultSettings()
        {
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = TimeFormat;
            chart1.Titles.Add(new Title(GraphText, Docking.Bottom, _titleFont, _titleColor));
            Text = GraphText;

            // Enable range selection and zooming UI by default
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
            //chart1.ChartAreas[0].CursorX.Interval = 5D;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Seconds;
            //chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 5D;


            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
        }

        private void InitNumberOfValues(string s)
        {
            Int32.TryParse(s, out _numberOfValues);
            if (_numberOfValues == 0)
                _numberOfValues = 20;
        }

        private void InitInterval(string s)
        {
            Int32.TryParse(s, out _interval);
            if (_interval == 0)
                _interval = 1;
        }

        private void Init()
        {
            chart1.Series.Clear();
            chart1.Legends[0].CustomItems.Clear();

            _numberOfComp = 0;
            if (_graphType == GraphType.Temperature)
                InitTemperature();
            else
                InitPressure();
        }

        private void InitTemperature()
        {
            foreach (var compressorSetting in Options.Compressors)
            {
                AddPoints(compressorSetting, compressorSetting.TemperatureValues);
                compressorSetting.TemperatureValues.ListChanged -= StatValuesOnListChanged;
                compressorSetting.TemperatureValues.ListChanged += StatValuesOnListChanged;
            }
        }
        
        private void InitPressure()
        {
            foreach (var compressorSetting in Options.Compressors)
            {
                AddPoints(compressorSetting, compressorSetting.PressureValues);
                compressorSetting.PressureValues.ListChanged -= StatValuesOnListChanged;
                compressorSetting.PressureValues.ListChanged += StatValuesOnListChanged;
            }
        }

        private void InitPoints(bool isPoints)
        {
            foreach (var series in chart1.Series.Where(u => u.Name.EndsWith(EndPointsName)))
            {
                var s = chart1.Series.FirstOrDefault(u => u.Name == series.Name.Replace(EndPointsName, string.Empty));
                if (s != null && s.Enabled)
                    series.Enabled = isPoints;
            }
        }

        private void InitValues(bool isValues)
        {
            foreach (var series in chart1.Series.Where(u => !u.Name.EndsWith(EndPointsName)))
            {
                series.IsValueShownAsLabel = isValues;
            }
        }

        private void ClearStatValues()
        {
            if (_graphType == GraphType.Temperature)
            {
                foreach (var compressorSetting in Options.Compressors)
                {
                    compressorSetting.TemperatureValues.Clear();
                }
            }
            else
            {
                foreach (var compressorSetting in Options.Compressors)
                {
                    compressorSetting.PressureValues.Clear();
                }
            }
        }

        #region Points

        private void AddPoints(CompressorSetting compressorSetting, IList<StatValue> statValues)
        {
            _numberOfComp++;
            var series = chart1.Series.Add($"Комп. {_numberOfComp} ({compressorSetting})");

            var list = new List<StatValue>();
            foreach (var statValue in statValues)
            {
                if (_lastDateTime.AddSeconds(_interval) > statValue.DateTime)
                    continue;
                list.Add(statValue);
                _lastDateTime = statValue.DateTime;
            }

            var values = list.Skip(list.Count - _numberOfValues).ToList();

            series.ChartType = SeriesChartType.Line;
            //series.SmartLabelStyle.Enabled = true;
            series.IsVisibleInLegend = false;
            series.Tag = statValues;

            AddCustomLegendItem(series);

            foreach (var statValue in values)
            {
                series.Points.AddXY(statValue.DateTime, statValue.Value);
            }

            AddPointSeries(series, values);
        }

        private void AddCustomLegendItem(Series series)
        {
            var legendItem = new LegendItem();
            legendItem.Cells.Add(new LegendCell
            {
                CellType = LegendCellType.Image,
                Image = _checked,
                //ImageSize = new Size(192, 192),
                ImageTransparentColor = Color.Red,
            });
            legendItem.Cells.Add(new LegendCell
            {
                CellType = LegendCellType.SeriesSymbol,
            });
            legendItem.Cells.Add(new LegendCell
            {
                Alignment = ContentAlignment.MiddleLeft,
                Text = series.Name
            });

            legendItem.BorderColor = Color.Transparent;
            //legendItem.BorderWidth = 2;
            chart1.ApplyPaletteColors();
            legendItem.Color = series.Color;
            legendItem.Tag = series;

            chart1.Legends[0].CustomItems.Add(legendItem);
        }

        private void AddPointSeries(Series series, IList<StatValue> statValues)
        {
            var s = chart1.Series.Add(series.Name + EndPointsName);

            s.ChartType = SeriesChartType.Point;
            //s.SmartLabelStyle.Enabled = true;
            s.IsVisibleInLegend = false;
            s.Tag = series.Tag;
            s.Color = series.Color;

            foreach (var statValue in statValues)
            {
                s.Points.AddXY(statValue.DateTime, statValue.Value);
            }
        }

        #endregion

        #region Events

        private void StatValuesOnListChanged(object sender, ListChangedEventArgs e)
        {
            if (!AutoRefresh)
                return;

            var list = sender as BindingList<StatValue>;
            if (list != null && e.ListChangedType == ListChangedType.ItemAdded)
            {
                Invoke(() =>
                {
                    var last = list.LastOrDefault();
                    if (last == null || _lastDateTime.AddSeconds(_interval) > last.DateTime)
                        return;

                    foreach (var series in chart1.Series.Where(u => u.Tag == sender))
                    {
                        series.Points.AddXY(last.DateTime, last.Value);
                        _lastDateTime = last.DateTime;
                        var needReset = false;
                        while (series.Points.Count > _numberOfValues)
                        {
                            series.Points.RemoveAt(0);
                            needReset = true;
                        }
                        if (needReset)
                        {
                            chart1.ChartAreas[0].RecalculateAxesScale();
                            //series.XValueType = ChartValueType.DateTime;
                        }
                    }
                });
            }
        }
        
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog()
            {
                Filter = "PNG файлы|*.png|Все файлы|*.*",
                Title = "Сохранить график как изображение",
                FileName = GraphText
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK &&
                    !string.IsNullOrWhiteSpace(dlg.FileName))
                {
                    try
                    {
                        chart1.SaveImage(dlg.FileName, ChartImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHelper.ShowException(ex);
                    }
                }
            }
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);
            // When user hits the LegendItem
            if (result?.Object is LegendItem)
            {
                // Legend item result
                var legendItem = (LegendItem) result.Object;

                // series item selected
                var selectedSeries = (Series) legendItem.Tag;

                if (selectedSeries != null)
                {
                    var pointSeries = chart1.Series.FirstOrDefault(u => u.Name == selectedSeries.Name + EndPointsName);

                    if (selectedSeries.Enabled)
                    {
                        selectedSeries.Enabled = false;
                        if (pointSeries != null) pointSeries.Enabled = false;
                        legendItem.Cells[0].Image = _unchecked;
                        legendItem.Cells[0].ImageTransparentColor = Color.Red;
                    }

                    else
                    {
                        selectedSeries.Enabled = true;
                        if (pointSeries != null) pointSeries.Enabled = Settings.IsPoints;
                        legendItem.Cells[0].Image = _checked;
                        legendItem.Cells[0].ImageTransparentColor = Color.Red;
                    }
                }
            }
        }

        private void ClearToolStripButton_Click(object sender, EventArgs e)
        {
            ClearStatValues();
            Init();
            chart1.Invalidate();
        }

        private void PointCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InitPoints(PointCheckBox.Checked);
        }

        private void ValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InitValues(ValuesCheckBox.Checked);
        }

        private void NumberNumericTextBox_TextChanged(object sender, EventArgs e)
        {
            InitNumberOfValues(NumberNumericTextBox.Text);

            var needReset = false;
            foreach (var series in chart1.Series)
            {
                while (series.Points.Count > _numberOfValues)
                {
                    needReset = true;
                    series.Points.RemoveAt(0);
                }
            }

            if (needReset)
            {
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
        }

        private void IntervalNumericTextBox_TextChanged(object sender, EventArgs e)
        {
            InitInterval(IntervalNumericTextBox.Text);
        }

        private void AutoRefreshToolStripButton_Click(object sender, EventArgs e)
        {
            Settings.GraphAutoRefresh = AutoRefresh = AutoRefresh == false;
        }
        
        #endregion
    }
}
