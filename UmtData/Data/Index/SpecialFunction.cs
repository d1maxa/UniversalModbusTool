using System;
using System.ComponentModel;

namespace UmtData.Data.Index
{
    [Flags]
    public enum SpecialFunction : long
    {
        None = 0x0,

        [Description("(не выбрано)")]
        NotSelected = 0x1,

        [Description("Статус работы(1)")]
        Status = 0x10,

        [Description("Давление")]
        Pressure = 0x100,

        [Description("Температура")]
        Temperature = 0x1000,

        [Description("Кнопка старта(1)")]
        StartButton = 0x10000,

        [Description("Кнопка остановки(1)")]
        StopButton = 0x100000,

        [Description("Кнопка сброса(1)")]
        ResetButton = 0x1000000,

        [Description("Статус работы(0)")]
        Status0 = 0x10000000,

        [Description("Кнопка старта(0)")]
        StartButton0 = 0x100000000,

        [Description("Кнопка остановки(0)")]
        StopButton0 = 0x1000000000,

        [Description("Кнопка сброса(0)")]
        ResetButton0 = 0x10000000000,
    }
}