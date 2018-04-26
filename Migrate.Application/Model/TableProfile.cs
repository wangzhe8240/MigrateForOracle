using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Application.Model
{
    /// <summary>
    /// 导出表的配置信息
    /// </summary>
    [Serializable]
    public class TableProfile
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 是否包含存储数据
        /// </summary>
        public bool IncludeStorage { get; set; }

        /// <summary>
        /// 是否包含约束
        /// </summary>
        public bool IncludeConstraint { get; set; }
    }
}
