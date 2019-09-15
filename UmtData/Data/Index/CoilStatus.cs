using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    /// <summary>
    /// однобитовый тип, доступен для чтения и записи
    /// </summary>
    public class CoilStatus : BaseIndex
    {
        public CoilStatus()
        {
            //DataType = typeof(bool);
        }

        //public override bool CannotChangeDataType => true;
    }
}