using System.ComponentModel;
using PropertyChanged;

namespace UmtData.Data.Index.Base
{
    [ImplementPropertyChanged]
    public abstract class BaseRegister : BaseIndex
    {
        [DisplayName("Единицы измерения")]
        public string Units { get; set; }

        [DisplayName("Мин. значение")]
        public decimal? Min { get; set; }

        [DisplayName("Макс. значение")]
        public decimal? Max { get; set; }

        [DisplayName("Множитель")]
        public decimal Multiplier { get; set; } = 1m;

        public int CustomType { get; set; } = 0;

        public override DataType DataType { get; set; } = DataType.Int16;
    }
}