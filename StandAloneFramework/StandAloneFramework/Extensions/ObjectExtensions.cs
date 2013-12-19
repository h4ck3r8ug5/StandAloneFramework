using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace StandAloneFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsObjectNotNull(this object value)
        {
            return value != null;
        }

        public static bool IsObjectNull(this object value)
        {
            return value == null;
        }

        public static string SerializeObject<T>(this object targetObject)
        {
            using (var ms = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.ASCII
                };

                var writer = XmlWriter.Create(ms, settings);
                var xmlNamespace = new XmlSerializerNamespaces();
                xmlNamespace.Add(string.Empty, string.Empty);
                xmlSerializer.Serialize(writer, targetObject, xmlNamespace);
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        public static T DeserializeObject<T>(this object targetObject) where T : class
        {
            var tempFileName = Path.GetTempFileName();
            string filename;

            if (targetObject.ToString().Contains("</"))
            {
                File.WriteAllText(tempFileName, targetObject.ToString());
                filename = tempFileName;
            }
            else
            {
                filename = targetObject.ToString();
            }
           
            var xmlSerializer = new XmlSerializer(typeof (T));

            using (var targetFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                var existingQuestions = (T)xmlSerializer.Deserialize(targetFileStream);

                return existingQuestions;
            }
        }
    }
}
