using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    /// <summary>
    /// 16-битовый знаковый или беззнаковый тип, доступен только для чтения
    /// </summary>
    public class InputRegister : BaseRegister
    {
        public InputRegister()
        {
            IsReadOnly = true;
            //DataType = typeof(short);
        }

        public override bool CanChangeReadOnly => false;
    }
}