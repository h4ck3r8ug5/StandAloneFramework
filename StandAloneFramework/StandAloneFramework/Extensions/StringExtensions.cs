// ***********************************************************************
// Assembly         : StandAloneFramework
// Author           : Charles Trent Spare
// Created          : 12-20-2013
//
// Last Modified By : Charles Trent Spare
// Last Modified On : 12-20-2013
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="">
//     Copyright (c) 2015. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using System.Linq;
using System.Text;

namespace StandAloneFramework.Extensions
{
    /// <summary>
    /// Represents a collection of extensions that can be used on any string object
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a strings current encoding into a target type of encoding. For e.g. convert an ASCII encoding into a UTF8
        /// </summary>
        /// <typeparam name="TEncodingType">The current encoding.</typeparam>
        /// <param name="targetEncoding">The target encoding.</param>
        /// <returns>System.String.</returns>
        public static string ConvertToEncodingType<TEncodingType>(this string value, TEncodingType targetEncoding)
        {
            var encoders = Encoding.GetEncodings();
            var encodingResult = encoders.FirstOrDefault(x => x.GetType() == typeof (TEncodingType));
            
            if (encodingResult.IsObjectNotNull())
            {
                var targetEncoder = encodingResult.GetEncoding();

                targetEncoder.EncoderFallback = new EncoderReplacementFallback(string.Empty);

                var sourceEncoder = value.GetStringEncoding();
                
                var sourceStringBytes = sourceEncoder.GetBytes(value);

                return targetEncoder.GetString(sourceStringBytes);
            }
            return null;
        }

        /// <summary>
        /// Gets the current encoding of the string
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Encoding.</returns>
        public static Encoding GetStringEncoding(this string source)
        {
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, source);

            using (var reader = new StreamReader(tempFile, true))
            {
                reader.ReadToEnd();

                return reader.CurrentEncoding;
            }
        }
    }
}
