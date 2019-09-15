using System;
using System.IO;
using System.Xml.Serialization;

namespace UmtData.Helpers
{
    public class XmlSaver<T> where T : new()
    {
        public static T Load(string fileName)
        {
            T obj;
            try
            {
                var optionsFile = FileHelper.GeneratePath(fileName);
                var serializer = new XmlSerializer(typeof(T));
                // A FileStream is needed to read the XML document.
                var fs = new FileStream(optionsFile, FileMode.Open);
                /* Use the Deserialize method to restore the object's state with  data from the XML document. */
                obj = (T)serializer.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                obj = new T();
            }
            return obj;
        }

        public static bool Save(T obj, string fileName)
        {
            var result = false;
            try
            {
                var optionsFile = FileHelper.GeneratePath(fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(optionsFile));
                var serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(optionsFile);
                serializer.Serialize(writer, obj);
                writer.Close();
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionHelper.ShowException(ex);
            }
            return result;
        }
    }
}