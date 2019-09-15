using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PropertyChanged;
using UmtData.Data.Index;

namespace UmtData.Data.Settings
{
    [ImplementPropertyChanged]
    public class CompressorSetting
    {
        [Browsable(false)]
        public ComPortSetting ComPortSetting => Options.Instance.ComPortSettings?.FirstOrDefault(u => u.Name == ComPortName);

        [Browsable(false)]
        public Indexes Indexes => Options.Instance.CompressorIndexes?.FirstOrDefault(u => u.Name == IndexesName);

        public string ComPortName { get; set; }

        public string IndexesName { get; set; }

        /// <summary>
        /// Внутренний адрес
        /// </summary>
        public byte Address { get; set; }

        public string SerialNumber { get; set; }

        public string Number { get; set; }

        public BindingList<StatValue> TemperatureValues { get; set; } = new BindingList<StatValue>();
        public BindingList<StatValue> PressureValues { get; set; } = new BindingList<StatValue>();
        
        public void AddTemperature(DateTime dateTime, decimal value)
        {
            TemperatureValues.Add(new StatValue(dateTime, value));
            //TemperatureValues.RemoveAll(u => u.DateTime < dateTime.AddDays(-1));
        }

        public void AddPressure(DateTime dateTime, decimal value)
        {
            PressureValues.Add(new StatValue(dateTime, value));
            //PressureValues.RemoveAll(u => u.DateTime < dateTime.AddDays(-1));
        }

        public void CopyFields(CompressorSetting c)
        {
            Address = c.Address;
            ComPortName = c.ComPortName;
            IndexesName = c.IndexesName;
            Number = c.Number;
            SerialNumber = c.SerialNumber;
        }

        public override string ToString()
        {
            return $"{IndexesName} {Number} {SerialNumber}";
        }
    }
}