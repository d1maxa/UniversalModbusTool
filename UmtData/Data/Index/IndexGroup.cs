using System.Collections;
using System.Collections.Generic;
using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    public class IndexGroup<T> where T:BaseIndex
    {
        public string Name { get; set; } = string.Empty;

        public List<T> Values { get; set; } = new List<T>();
    }
}