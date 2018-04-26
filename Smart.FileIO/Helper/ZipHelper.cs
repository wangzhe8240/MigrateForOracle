using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.IO;

namespace Smart.FileIO
{
    /// <summary>
    /// Zip压缩帮助类
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="fileList">文件列表(绝对路径)</param>
        /// <param name="zipName">压缩后的文件名称(绝对路径)</param>
        /// <param name="compressionLevel">压缩率0（无压缩）9（压缩率最高）</param>
        public static void Zip(string[] fileList, string zipName, int compressionLevel = 9)
        {
            using (var zstream = new ZipOutputStream(File.Create(zipName)))
            {
                zstream.SetLevel(compressionLevel);

                foreach (string item in fileList)
                {
                    FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(Path.GetFileName(item))
                    {
                        DateTime = DateTime.Now,
                        Size = fs.Length
                    };
                    fs.Close();
                    Crc32 crc = new Crc32();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zstream.PutNextEntry(entry);
                    zstream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        /// <summary> 
        /// 功能：解压zip格式的文件。 
        /// </summary> 
        /// <param name="zipFile"></param>
        public static List<string> UnZip(string zipFile, string destDir = "")
        {
            string dir = destDir;
            if (string.IsNullOrEmpty(dir))
            {
                dir = Path.Combine(Path.GetDirectoryName(zipFile), Path.GetFileNameWithoutExtension(zipFile));
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            List<string> files = new List<string>();

            using (var s = new ZipInputStream(File.OpenRead(zipFile)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    files.Add(theEntry.Name);
                    using (FileStream streamWriter = File.Create(Path.Combine(dir, theEntry.Name)))
                    {
                        byte[] data = new byte[1024 * 5];
                        while (s.Read(data, 0, data.Length) > 0)
                        {
                            streamWriter.Write(data, 0, data.Length);
                        }
                    }
                }
            }

            return files;
        }
    }
}
