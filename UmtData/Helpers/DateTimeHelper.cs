using System;

namespace UmtData.Helpers
{
    public static class DateTimeHelper
    {
        public static string GetNowTime()
        {
            return DateTime.Now.ToString("[HH:mm:ss]");
        }
    }
}