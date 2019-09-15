using System;
using System.IO;

namespace UmtData.Helpers
{
    public static class FileHelper
    {
        public static string GeneratePath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "UniversalModbusTool", fileName);
        }
    }
}