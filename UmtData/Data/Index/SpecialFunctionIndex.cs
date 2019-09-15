using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    public class SpecialFunctionIndex
    {
        public SpecialFunctionIndex()
        { }

        public SpecialFunctionIndex(SpecialFunction specialFunction, BaseIndex baseIndex)
        {
            SpecialFunction = specialFunction;
            Index = baseIndex;
        }

        public SpecialFunction SpecialFunction { get; set; }

        public BaseIndex Index { get; set; }
    }
}