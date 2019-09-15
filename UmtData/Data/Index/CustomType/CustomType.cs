using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using PropertyChanged;

namespace UmtData.Data.Index.CustomType
{
    public class CustomType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BindingList<CustomValue> _values = new BindingList<CustomValue>();
        private string _name;
        public static int _myId = 1;

        public CustomType()
        {
            _name = string.Empty;
            Id = _myId++;
        }

        public int BaseId
        {
            get { return _myId; }
            set { _myId = value; }
        }

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public BindingList<CustomValue> Values
        {
            get { return _values; }
            set
            {
                if (_values != value)
                {
                    if (_values != null)
                        _values.ListChanged -= _values_ListChanged;
                    _values = value;
                    OnPropertyChanged(nameof(Values));
                    if (_values != null)
                    {
                        _values.ListChanged -= _values_ListChanged;
                        _values.ListChanged += _values_ListChanged;
                    }
                }
            }
        }

        private void _values_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Values));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}