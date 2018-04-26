using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Smart.FileIO.Model;

namespace Smart.FileIO
{
    public class PartialWriter
    {
        internal PartialWriter(string fileName, string workDirectory)
        {
            Header = new PartialHeader
            {
                FileName = fileName
            };
            WorkDirectory = workDirectory;

            initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="workDirectory">工作目录</param>
        /// <param name="enablePage">启用分页</param>
        /// <param name="maxSize">文件大小</param>
        internal PartialWriter(string fileName, string workDirectory, bool enablePage = false, int maxSize = 5)
        {
            Header = new PartialHeader
            {
                FileName = fileName,
                EnablePage = enablePage,
                MaxSize = maxSize
            };
            WorkDirectory = workDirectory;

            initialize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initialize()
        {
            fileList = new List<string>();
            fs = new FileStream(Path.Combine(WorkDirectory, $"{Header.FileName}._{currentPage}"), FileMode.CreateNew);

            currentPos = fs.Position;
            fileList.Add(fs.Name);
        }

        public PartialHeader Header { get; set; }

        public string WorkDirectory { get; set; }

        private FileStream fs { get; set; }

        private List<string> fileList { get; set; }

        /// <summary>
        /// 当前页面
        /// </summary>
        private int currentPage { get; set; }

        /// <summary>
        /// 指针的当前位置
        /// </summary>
        private long currentPos { get; set; }

        public void Append(string name, object content)
        {
            if (name == "header")
            {
                throw new Exception($"header为保留关键字，不允许使用。");
            }
            if (Header.Where(item => item.Name == name).Count() > 0)
            {
                throw new Exception($"已存在同名的数据项{name}");
            }
            byte[] data = BinaryHelper.Serialize(content);
            if (Header.EnablePage)
            {
                if (currentPos + data.Length > Header.MaxSize * 1024 * 1024)
                {
                    fs.Close();
                    currentPage++;
                    fs = new FileStream(Path.Combine(WorkDirectory, $"{Header.FileName}._{currentPage}"), FileMode.CreateNew);
                    fileList.Add(fs.Name);
                    currentPos = fs.Position;
                }
            }

            Header.Add(new DataEntry
            {
                Name = name,
                PageNum = currentPage,
                Offset = currentPos,
                Length = data.Length
            });

            fs.Write(data, 0, data.Length);
            currentPos = fs.Position;
        }

        public void Commit()
        {
            fs.Close();
            writeHeader();
            ZipHelper.Zip(fileList.ToArray(), Path.Combine(WorkDirectory, Header.FileName));
            clear();
        }

        private void writeHeader()
        {
            fs = new FileStream(Path.Combine(WorkDirectory, $"{Header.FileName}.header"), FileMode.CreateNew);
            fileList.Add(fs.Name);
            byte[] data = BinaryHelper.Serialize(Header);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        private void clear()
        {
            foreach (var path in fileList)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
