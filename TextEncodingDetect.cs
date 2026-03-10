using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffmpeg_mini_gui
{
    internal static class TextEncodingDetect
    {
        //
        // other libraries
        // https://www.nuget.org/packages/UDE.CSharp
        // https://github.com/AutoItConsulting/text-encoding-detect
        //
        internal static bool IsUTF8withBom(string filePath)
        {
            // UTF-8 BOM bytes: 0xEF, 0xBB, 0xBF
            byte[] utf8Bom = Encoding.UTF8.GetPreamble();
            byte[] fileStartBytes = new byte[utf8Bom.Length];

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length >= utf8Bom.Length)
                {
                    fs.Read(fileStartBytes, 0, fileStartBytes.Length);
                }
            }

            for (int i = 0; i < utf8Bom.Length; i++)
            {
                if (fileStartBytes[i] != utf8Bom[i])
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool IsUTF8(string filePath)
        {
            // Use a strict UTF8Encoding that throws an exception on invalid bytes and does not use a BOM.
            var strictUtf8 = new UTF8Encoding(false, true);

            try
            {
                byte[] data = File.ReadAllBytes(filePath);

                strictUtf8.GetString(data);

                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
