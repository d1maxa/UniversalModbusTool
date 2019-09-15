using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    /// <summary>
    /// 16-битовый знаковый или беззнаковый тип, доступен для чтения и записи
    /// </summary>
    public class HoldRegister : BaseRegister
    {
        public HoldRegister()
        {
            //DataType = typeof(short);
        }
    }
}