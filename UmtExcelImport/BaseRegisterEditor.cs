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
    public partial class BaseRegisterEditor : BaseIndexEditor
    {
        public BaseRegisterEditor()
        {
            InitializeComponent();
            comboBox2.DataSource = EnumHelper.GenerateValueListFromEnum<DataType>().OrderBy(u => u.Value).ToList();
        }

        public BaseRegister BaseRegister
        {
            get { return bindingSource1.DataSource as BaseRegister; }
            set
            {
                bindingSource1.DataSource = value;
                CheckItems();
            }
        }

        public object CustomTypes
        {
            set { comboBox1.DataSource = value; }
        }
    }
}
