using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.FileIO.Model;
using System.IO;

namespace Smart.FileIO
{
    public class Reader : IDisposable
    {
        public Reader(string fileName, string directory = "")
        {
            WorkDirectory = directory;
            initialize(fileName);
        }

        internal string WorkDirectory { get; set; }

        public SummaryHeader Header { get; private set; }

        private List<string> fileList { get; set; }

        private void initialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception($"不存在文件{fileName}");
            }

            if (string.IsNullOrEmpty(WorkDirectory))
            {
                WorkDirectory = System.Environment.GetEnvironmentVariable("TEMP");
            }

            if (string.IsNullOrEmpty(WorkDirectory))
            {
                string dir = Path.GetDirectoryName(fileName);
                string file = Path.GetFileNameWithoutExtension(fileName);

                WorkDirectory = Path.Combine(dir, file);
            }

            fileList = ZipHelper.UnZip(fileName, WorkDirectory);

            string headerFile = Directory.GetFiles(WorkDirectory).Where(item => Path.GetFileName(item) == $"{Path.GetFileName(fileName)}.header").FirstOrDefault();

            if (!File.Exists(headerFile))
            {
                throw new Exception($"未能在目录{WorkDirectory}找到.header文件");
            }

            Header = BinaryHelper.Deserialize<SummaryHeader>(File.ReadAllBytes(headerFile));

            validateMD5();
        }

        public PartialReader ReadPartial(FileEntry entry)
        {
            return new PartialReader(entry, WorkDirectory);
        }

        /// <summary>
        /// 校验MD5
        /// </summary>
        private void validateMD5()
        {
            string origin = Header.MD5;
            StringBuilder hash = new StringBuilder();
            Header.MD5 = Writer.SECRET_KEY;
            hash.Append(MD5Helper.ComputeHash(BinaryHelper.Serialize(Header)));

            for (int i = 0; i < Header.Count; i++)
            {
                using (FileStream fs = new FileStream(Path.Combine(WorkDirectory, Header[i].FileName), FileMode.Open))
                {
                    hash.Append(MD5Helper.ComputeHash(fs));
                }
            }

            string current = MD5Helper.ComputeHash(hash.ToString());

            if (origin != current)
            {
                //throw new Exception("MD5校验值不一致，文件已被修改");
            }

            Header.MD5 = origin;

        }

        ~Reader()
        {
            Dispose();
        }

        public void Dispose()
        {
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