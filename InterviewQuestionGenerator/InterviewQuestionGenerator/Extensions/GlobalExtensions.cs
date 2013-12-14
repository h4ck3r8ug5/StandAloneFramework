using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using InterviewQuestionGenerator.Handlers;

namespace InterviewQuestionGenerator.Extensions
{
    public static class GlobalExtensions
    {
        internal static string SerializeObject<T>(this object targetObject)
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
                xmlNamespace.Add("", "");
                xmlSerializer.Serialize(writer, targetObject, xmlNamespace);
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        internal static Tuple<T,SystemMessage> DeserializeObject<T>(this object targetObject) where T : class
        {
            try
            {                
                var tempFileName = Path.GetTempFileName();
                string filename;

                var targetStringFileExtension = Path.GetExtension(targetObject.ToString());
                if (!targetStringFileExtension.IsObjectNotNull())
                {
                    filename = targetObject.ToString();                    
                }
                else
                {
                    File.WriteAllText(tempFileName, targetObject.ToString());
                    filename = tempFileName;
                }

                var xmlSerializer = new XmlSerializer(typeof(QuestionAnswerSet));

                using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var existingQuestions = (QuestionAnswerSet)xmlSerializer.Deserialize(fileStream);

                    return new Tuple<T, SystemMessage>((T) (object) existingQuestions, null);
                }
            }
            catch (Exception ex)
            {
                MessageHandler.ShowFailMessage(MessageHandler.FailMessageType.InterviewFileDoesNotExist);
                return new Tuple<T, SystemMessage>(default(T),new SystemMessage
                {
                    MessageType = SystemMessage.SystemMessageType.Error,
                    MessageText = ex.Message
                });
            }
        }

        internal static string GetInterviewFile(this NameValueCollection value, string targetString)
        {
            try
            {
                return value[targetString];
            }
            catch (Exception)
            {
                MessageHandler.ShowFailMessage(MessageHandler.FailMessageType.InterviewFileDoesNotExist);
                return string.Empty;
            }
        }

        internal static bool IsObjectNotNull(this object value)
        {
            return value != null;
        }

        internal static bool IsObjectNull(this object value)
        {
            return value == null;
        }
    }
}
