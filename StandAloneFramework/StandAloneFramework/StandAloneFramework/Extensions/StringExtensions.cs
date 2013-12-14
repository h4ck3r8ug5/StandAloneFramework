using System.IO;
using System.Linq;
using System.Text;

namespace StandAloneFramework.Extensions
{
    public static class StringExtensions
    {
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
