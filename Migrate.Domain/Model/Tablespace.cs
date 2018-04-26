using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Model
{
    /// <summary>
    /// 表空间
    /// </summary>
    public class Tablespace
    {
        /// <summary>
        /// 表空间名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据文件的存储路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 数据文件初始大小,单位M
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 是否自动扩展
        /// </summary>
        public bool AutoExtend { get; set; }

        /// <summary>
        /// 扩展的大小,单位M
        /// </summary>
        public int ExtendSize { get; set; }

        /// <summary>
        /// 数据文件的最大大小
        /// </summary>
        public int MaxSize { get; set; }
    }
}
