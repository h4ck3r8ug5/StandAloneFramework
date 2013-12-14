using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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

        internal static T DeserializeObject<T>(this object targetObject, FileStream targetFileStream) where T : class
        {
            var tempFileName = Path.GetTempFileName();
            string filename;

            var targetStringFileExtension = Path.GetExtension(targetObject.ToString());
            if (!string.IsNullOrEmpty(targetStringFileExtension))
            {
                filename = targetObject.ToString();
            }
            else
            {
                File.WriteAllText(tempFileName, targetObject.ToString());
                filename = tempFileName;
            }

            //TODO: Add opr check how this is being called cos the old way used to use an internal filestream using the abouve if checks
            var xmlSerializer = new XmlSerializer(typeof(QuestionAnswerSet));

            var existingQuestions = (QuestionAnswerSet)xmlSerializer.Deserialize(targetFileStream);

            return (T)(object)existingQuestions;          
        }

        internal static string GetInterviewFile(this NameValueCollection value, string targetString)
        {
            try
            {
                return value[targetString];
            }
            catch (Exception)
            {
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

        internal static void AddToList<T>(this IList<T> sourceList, T value)
        {
            sourceList.Add(value);
        }
     
        internal static object GetKey<T1,T2>(this Dictionary<T1,T2> targetDictionary, object targetValue)
        {
            var sortedList = new SortedList();

            targetDictionary.Keys.ToList().ForEach(key => sortedList.Add(key,targetDictionary[key]));

            return sortedList.GetKey(sortedList.IndexOfValue(targetValue));
        }
    }
}
