using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UmtData.Data.Index;
using UmtData.Data.Index.CustomType;

namespace UmtExcelImport
{
    public partial class CustomTypeEditor : UserControl
    {
        public CustomTypeEditor()
        {
            InitializeComponent();
        }

        public CustomType CustomType
        {
            get { return bindingSource1.DataSource as CustomType; }
            set { bindingSource1.DataSource = value; }
        }

        public void UpdateGrid()
        {
            dataGridView1.EndEdit();
        }
    }
}
