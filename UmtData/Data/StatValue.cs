using System;

namespace UmtData.Data
{
    public class StatValue
    {
        public StatValue(){ }

        public StatValue(DateTime d, decimal v)
        {
            DateTime = d;
            Value = v;
        }

        public DateTime DateTime { get; set; }

        public decimal Value { get; set; }
    }
}