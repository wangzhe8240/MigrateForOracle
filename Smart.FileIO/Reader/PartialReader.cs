using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.FileIO.Model;
using System.IO;

namespace Smart.FileIO
{
    public class PartialReader : IDisposable
    {
        internal PartialReader(FileEntry entry, string workDirectory)
        {
            FileEntry = entry;
            WorkDirectory = workDirectory;
            initialize();
        }

        public FileEntry FileEntry { get; private set; }

        public PartialHeader Header { get; private set; }

        public string WorkDirectory { get; private set; }

        /// <summary>
        /// 文件流
        /// </summary>
        private FileStream fs { get; set; }

        /// <summary>
        /// 当前页面
        /// </summary>
        private int currentPage { get; set; }

        /// <summary>
        /// 指针的当前位置
        /// </summary>
        private long currentPos { get; set; }

        /// <summary>
        /// 解压出的文件列表
        /// </summary>
        private List<string> fileList { get; set; }

        private void initialize()
        {
            fileList = ZipHelper.UnZip(Path.Combine(WorkDirectory, FileEntry.FileName), WorkDirectory);

            string headerFile = Directory.GetFiles(WorkDirectory).Where(item => Path.GetFileName(item) == $"{FileEntry.FileName}.header").FirstOrDefault();

            if (!File.Exists(headerFile))
            {
                throw new Exception($"未能在目录{WorkDirectory}找到.header文件");
            }

            Header = BinaryHelper.Deserialize<PartialHeader>(File.ReadAllBytes(headerFile));
        }

        public object Read(DataEntry entry)
        {
            if (fs == null)
            {
                fs = new FileStream(Path.Combine(WorkDirectory, $"{Header.FileName}._{entry.PageNum}"), FileMode.Open);
                currentPage = entry.PageNum;
                currentPos = fs.Position;
            }
            if (currentPage != entry.PageNum)
            {
                fs = new FileStream(Path.Combine(WorkDirectory, $"{Header.FileName}._{entry.PageNum}"), FileMode.Open);
                currentPage = entry.PageNum;
                currentPos = fs.Position;
            }
            if (currentPos != entry.Offset)
            {
                fs.Seek(entry.Offset, SeekOrigin.Begin);
                currentPos = fs.Position;
            }

            byte[] data = new byte[entry.Length];

            fs.Read(data, 0, entry.Length);
            currentPos = fs.Position;

            return BinaryHelper.Deserialize(data);
        }

        public T Read<T>(DataEntry entry) where T : class
        {
            return Read(entry) as T;
        }

        ~PartialReader()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (fs != null) fs.Close();

            foreach (var path in fileList)
            {
                string file = Path.Combine(WorkDirectory, path);
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
