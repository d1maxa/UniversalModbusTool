using System.ComponentModel;
using PropertyChanged;
using UmtData.Data.Settings;
using System.Drawing;

namespace UmtData.Data
{
    [ImplementPropertyChanged]
    public class CompressorData
    {
        [Browsable(false)]
        public bool? InnerStatus { get; set; }
        public string Status => InnerStatus == null ? "-" : (InnerStatus.Value ? "Работает" : "Остановлен");
        public Color StatusColor => InnerStatus == null ? Color.Gray : (InnerStatus.Value ? Color.Green : Color.Red);

        public bool StartEnabled => InnerStatus != null && !InnerStatus.Value;
        public bool StopEnabled => InnerStatus != null && InnerStatus.Value;
        public bool ResetEnabled => InnerStatus != null;

        public Color StartColor => StartEnabled ? Color.YellowGreen : Color.DarkGray;
        public Color StopColor => StopEnabled ? Color.LightCoral : Color.DarkGray;
        public Color ResetColor => ResetEnabled ? Color.LightSkyBlue : Color.DarkGray;

        public string Pressure { get; set; }
        public string Temperature { get; set; }
    }
}