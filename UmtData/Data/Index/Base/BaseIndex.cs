using System;
using System.ComponentModel;
using PropertyChanged;

namespace UmtData.Data.Index.Base
{
    [ImplementPropertyChanged]
    public abstract class BaseIndex
    {
        [DisplayName("Адрес")]
        public ushort Address { get; set; }
        
        public ushort RealAddress => ConvertAddress(Address);

        [DisplayName("Название")]
        public string Function { get; set; } = string.Empty;

        [DisplayName("Только для чтения")]
        public bool IsReadOnly { get; set; }

        public SpecialFunction SpecialFunction { get; set; } = SpecialFunction.NotSelected;
        
        public virtual DataType DataType { get; set; } = DataType.Digital;

        //public virtual bool CannotChangeDataType => false;

        public virtual bool CanChangeReadOnly => true;

        private static ushort ConvertAddress(ushort address)
        {
            var result = (ushort)(address - 1);
            if (result >= 10000)
                result = (ushort)(result % 10000);
            return result;
        }
    }
}