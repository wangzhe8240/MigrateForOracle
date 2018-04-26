using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.FileIO.Model;
using System.IO;

namespace Smart.FileIO
{
    public class Writer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="workDirectory">工作目录</param>
        public Writer(string fileName, string workDirectory = "")
        {
            WorkDirectory = workDirectory;
            if (string.IsNullOrEmpty(WorkDirectory))
            {
                WorkDirectory = Path.GetDirectoryName(fileName);
            }
            if (string.IsNullOrEmpty(WorkDirectory))
            {
                throw new Exception("未指定工作目录");
            }
            Header = new SummaryHeader
            {
                FileName = Path.GetFileName(fileName)
            };

            fileList = new List<string>();
        }

        /// <summary>
        /// 工作目录
        /// </summary>
        internal string WorkDirectory { get; set; }

        internal SummaryHeader Header { get; set; }

        /// <summary>
        /// 创建分部文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public PartialWriter CreatePartial(string name, string description = "")
        {
            if (name == "header")
            {
                throw new Exception($"header为保留关键字，不允许使用。");
            }

            string partialName = getPartialName(name);

            if (exists(partialName))
            {
                throw new Exception($"已存在同名的文件{name}");
            }
            Header.Add(new FileEntry
            {
                Name = name,
                FileName = partialName,
                Description = description
            });

            addPartialFile(partialName);

            return new PartialWriter(partialName, WorkDirectory);
        }


        /// <summary>
        /// 创建分部文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="enablePage"></param>
        /// <param name="description"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public PartialWriter CreatePartial(string name, bool enablePage, string description = "", int maxSize = 5)
        {
            if (name == "header")
            {
                throw new Exception($"header为保留关键字，不允许使用。");
            }

            string partialName = getPartialName(name);

            if (exists(partialName))
            {
                throw new Exception($"已存在同名的分部文件{name}");
            }
            Header.Add(new FileEntry
            {
                Name = name,
                FileName = partialName,
                Description = description
            });


            addPartialFile(partialName);

            return new PartialWriter(partialName, WorkDirectory, enablePage, maxSize);
        }

        public void Commit()
        {
            // 计算Hash
            computeMD5();

            writeHeader();

            ZipHelper.Zip(fileList.ToArray(), Path.Combine(WorkDirectory, Header.FileName));

            clear();
        }

        /// <summary>
        /// 分部文件列表
        /// </summary>
        private List<string> fileList { get; set; }

        private void addPartialFile(string file)
        {
            fileList.Add(Path.Combine(WorkDirectory, file));
        }

        private string getPartialName(string name)
        {
            return $"{Header.FileName}.partial_{name}";
        }

        /// <summary>
        /// 已存在同名的文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private bool exists(string filename)
        {
            return Header.Where(item => item.FileName == filename).Count() > 0;
        }

        /// <summary>
        /// 将头部信息写入文件
        /// </summary>
        private void writeHeader()
        {
            string partialName = $"{Header.FileName}.header";

            addPartialFile(partialName);

            FileStream fs = new FileStream(Path.Combine(WorkDirectory, partialName), FileMode.CreateNew);
            byte[] data = BinaryHelper.Serialize(Header);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }

        /// <summary>
        /// 删除中间文件
        /// </summary>
        public void clear()
        {
            foreach (var path in fileList)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void computeMD5()
        {
            StringBuilder hash = new StringBuilder();

            Header.MD5 = SECRET_KEY;

            hash.Append(MD5Helper.ComputeHash(BinaryHelper.Serialize(Header)));

            for (int i = 0; i < Header.Count; i++)
            {
                using (FileStream fs = new FileStream(Path.Combine(WorkDirectory, Header[i].FileName), FileMode.Open))
                {
                    hash.Append(MD5Helper.ComputeHash(fs));
                }
            }

            Header.MD5 = MD5Helper.ComputeHash(hash.ToString());
        }

        /// <summary>
        /// 密钥
        /// </summary>
        internal const string SECRET_KEY = "123456";
    }
}
