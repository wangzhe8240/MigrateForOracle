using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.FileIO.Model
{
    [Serializable]
    public class FileEntry
    {
        /// <summary>
        /// 标识符
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{FileName}:{Description}";
        }
    }
}
