using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.FileIO.Model
{
    [Serializable]
    public class SummaryHeader : List<FileEntry>
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        public string MD5 { get; internal set; }

        public FileEntry this[string name]
        {
            get
            {
                FileEntry result = null;
                foreach (var item in this)
                {
                    if (item.Name == name)
                    {
                        result = item;
                        break;
                    }
                }
                if (result == null)
                {
                    throw new IndexOutOfRangeException($"不存在{name}");
                }
                return result;
            }
        }
    }
}
