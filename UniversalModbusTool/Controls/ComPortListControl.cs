using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using UmtData.Data;
using UniversalModbusTool.Core;

namespace UniversalModbusTool.Controls
{
    public partial class ComPortListControl : BaseUserControl
    {
        private readonly ComPortList _comPortList = new ComPortList();

        public ComPortListControl()
        {
            InitializeComponent();
        }
        
        public override void Initialize()
        {
            base.Initialize();

            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.Controls.Add(_comPortList);
            _comPortList.Initialize();

            ComPortInitializer.Initialize();
            foreach (var x in Options.ComPortSettings)
            {
                flowLayoutPanel1.Controls.Add(new ComPortEditor(x));
                (x as INotifyPropertyChanged).PropertyChanged -= ComPortListControl_PropertyChanged;
                (x as INotifyPropertyChanged).PropertyChanged += ComPortListControl_PropertyChanged;
            }
        }

        private void ComPortListControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Options.SaveComPorts();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}
