using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    /// <summary>
    /// однобитовый тип, доступен только для чтения
    /// </summary>
    public class InputStatus : BaseIndex
    {
        public InputStatus()
        {
            //DataType = typeof(bool);
            IsReadOnly = true;
        }

        public override bool CanChangeReadOnly => false;

        //public override bool CannotChangeDataType => true;
    }
}