// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="ObjectExtensions.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace StandAloneFramework.Extensions
{
    /// <summary>
    /// Represents the object extensions that can be used on any object
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determines whether an object not null
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if an object is not null; otherwise, <c>false</c>.</returns>
        public static bool IsObjectNotNull(this object value)
        {
            return value != null;
        }

        /// <summary>
        /// Determines whether an object null
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if an object null; otherwise, <c>false</c>.</returns>
        public static bool IsObjectNull(this object value)
        {
            return value == null;
        }

        /// <summary>
        /// Serializes the object into a string.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize</typeparam>
        /// <param name="targetObject">The target object to serialize.</param>
        /// <returns>System.String.</returns>
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

        /// <summary>
        /// Deserializes the string into an object.
        /// </summary>
        /// <typeparam name="T">The target type of the deserialized object</typeparam>
        /// <param name="targetObject">The target object.</param>
        /// <returns>An instance of the target type of the serialized object</returns>
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

        /// <summary>
        /// Disposes the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        public static void Dispose<T>(this T instance)
        {
            if (instance is IDisposable)
            {
                (instance as IDisposable).Dispose();
            }
        }
    }
}
