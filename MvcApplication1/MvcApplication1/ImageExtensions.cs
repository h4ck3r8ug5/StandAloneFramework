using System.IO;

namespace MvcApplication1
{
    public static class ImageExtensions
    {
        public static string GetImageFromBinaryData(this byte[] source, string path)
        {           
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                filestream.Write(source, 0, source.Length);
                filestream.Flush();

                return Path.GetFileName(path);
            }
        }

        public static byte[] GetImageBinaryData(this string source)
        {
            using (var fs = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[(int)fs.Length];

                fs.Read(bytes, 0, bytes.Length);

                fs.Flush();

                return bytes;
            }
        }
    }
}