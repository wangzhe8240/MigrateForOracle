using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.FileIO.Model
{
    /// <summary>
    /// 数据条目
    /// </summary>
    [Serializable]
    public class DataEntry
    {
        /// <summary>
        /// 条目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件流偏移量 
        /// </summary>
        public long Offset { get; internal set; }

        /// <summary>
        /// 数据长度
        /// </summary>
        public int Length { get; internal set; }

        /// <summary>
        /// 页码数
        /// </summary>
        public int PageNum { get; internal set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string MD5 { get; set; }

        public override string ToString()
        {
            return $"{Name}:{Offset}:{Length}:{PageNum}";
        }
    }
}
