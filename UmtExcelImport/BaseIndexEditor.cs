using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Helpers;

namespace UmtExcelImport
{
    public partial class BaseIndexEditor : UserControl
    {
        private bool _stopEvent;
        private readonly IList<SpecialFunction> _specialFunctions;

        public BaseIndexEditor()
        {
            InitializeComponent();
            var list = EnumHelper.GenerateListFromEnum<SpecialFunction>();
            list.RemoveAt(0);

            _specialFunctions = list.Select(u => u.Key).ToList();
            foreach (var s in list.Select(u => u.Value))
            {
                SpecialFunctionCheckedComboBox.Items.Add(s);
            }
        }
        
        public BaseIndex BaseIndex
        {
            get { return bindingSource1.DataSource as BaseIndex; }
            set
            {
                bindingSource1.DataSource = value;
                CheckItems();
            }
        }

        protected void CheckItems()
        {
            var i = 0;
            var sf = BaseIndex.SpecialFunction;
            _stopEvent = true;
            foreach (var f in _specialFunctions)
            {
                SpecialFunctionCheckedComboBox.SetItemChecked(i, sf.HasFlag(f));
                i++;
            }
            _stopEvent = false;
        }

        private void checkedComboBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(_stopEvent)
                return;

            var result = BaseIndex.SpecialFunction;

            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    //не даем снять галку с первого
                    e.NewValue = CheckState.Checked;
                    return;
                }

                if (e.NewValue == CheckState.Checked)
                {
                    //снимаем все галки кроме первой
                    _stopEvent = true;
                    for (var i = 1; i < _specialFunctions.Count; i++)
                    {
                        SpecialFunctionCheckedComboBox.SetItemChecked(i, false);
                    }
                    _stopEvent = false;

                    result = SpecialFunction.NotSelected;
                }
            }
            else if (e.NewValue == CheckState.Checked)
            {
                //снимаем галку с первого если выделили новое
                _stopEvent = true;
                SpecialFunctionCheckedComboBox.SetItemChecked(0, false);
                _stopEvent = false;

                result = EnumHelper.RemoveFlag(result, SpecialFunction.NotSelected);
                result = result | _specialFunctions[e.Index];
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                result = EnumHelper.RemoveFlag(result, _specialFunctions[e.Index]);
                if (result == SpecialFunction.None)
                {
                    //сняли галки со всех, значит ничего не выбрано
                    _stopEvent = true;
                    SpecialFunctionCheckedComboBox.SetItemChecked(0, true);
                    _stopEvent = false;
                    result = SpecialFunction.NotSelected;
                }
            }

            BaseIndex.SpecialFunction = result;
        }
    }
}
