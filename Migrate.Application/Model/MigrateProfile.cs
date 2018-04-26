using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper.Access;

namespace Migrate.Application.Model
{
    /// <summary>
    /// 迁移配置信息
    /// </summary>
    public class MigrateProfile
    {
        /// <summary>
        /// 源数据库链接字符串
        /// </summary>
        public ConnectString SourceConnString { get; set; }

        /// <summary>
        /// 目标数据库链接字符串
        /// </summary>
        public ConnectString DestConnString { get; set; }

        /// <summary>
        /// 导出或导入的文件
        /// </summary>
        public string TargetFile { get; set; }

        /// <summary>
        /// 目标数据库的表空间
        /// </summary>
        public string DestTablespace { get; set; }

        /// <summary>
        /// 导出表
        /// </summary>
        public IList<TableProfile> ImpTables { get; set; }
    }
}
