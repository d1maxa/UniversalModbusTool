using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UmtData.Constants;
using UmtData.Data.Index;
using UmtData.Helpers;

namespace UmtData.Data.Settings
{
    public class Options : Singleton<Options>
    {
        public List<ComPortSetting> ComPortSettings { get; set; }

        public List<Indexes> CompressorIndexes { get; set; }

        public List<CompressorSetting> Compressors { get; set; }
        
        public void LoadOptions()
        {
            ComPortSettings = XmlSaver<List<ComPortSetting>>.Load(FileNames.ComPorts);
            Compressors = XmlSaver<List<CompressorSetting>>.Load(FileNames.Compressors);
            //ClearCompressorsValues();
            LoadCompressorIndexes();
        }
        
        public void SaveComPorts()
        {
            XmlSaver<List<ComPortSetting>>.Save(ComPortSettings, FileNames.ComPorts);
        }

        public void SaveCompressors()
        {
            ClearCompressorsValues();
            XmlSaver<List<CompressorSetting>>.Save(Compressors, FileNames.Compressors);
        }

        private void ClearCompressorsValues()
        {
            if (Compressors == null)
                return;

            var yesterday = DateTime.Now.AddDays(-1);

            foreach (var compressorSetting in Compressors)
            {
                //лучше их хранить в sql compact?
                compressorSetting.TemperatureValues.Clear();
                compressorSetting.PressureValues.Clear();

                /*
                var list = new List<StatValue>(compressorSetting.TemperatureValues);
                foreach (var statValue in list.Where(statValue => statValue.DateTime < yesterday))
                {
                    compressorSetting.TemperatureValues.Remove(statValue);
                }

                var list2 = new List<StatValue>(compressorSetting.PressureValues);
                foreach (var statValue in list2.Where(statValue => statValue.DateTime < yesterday))
                {
                    compressorSetting.PressureValues.Remove(statValue);
                }
                */

                /*
                compressorSetting.TemperatureValues.RemoveAll(u => u.DateTime < DateTime.Now.AddDays(-1));
                compressorSetting.PressureValues.RemoveAll(u => u.DateTime < DateTime.Now.AddDays(-1));
                */
            }
        }

        public void LoadCompressorIndexes()
        {
            var x = new List<Indexes>();
            try
            {
                x.AddRange(Directory.GetFiles(Path.Combine(Application.StartupPath, "Models")).Select(XmlSaver<Indexes>.Load));
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowException(ex);
            }
            CompressorIndexes = x;
        }

        public void InitMasterSettings()
        {
            var list = ComPortSettings;
            if (list == null) return;
            foreach (var comPortSetting in ComPortSettings)
            {
                comPortSetting.InitMaster();
            }
        }
    }
}