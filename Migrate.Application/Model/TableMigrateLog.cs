using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Application.Model
{
    /// <summary>
    /// 数据表迁移日志
    /// </summary>
    public class TableMigrateLog
    {
        /// <summary>
        /// 表结构状态
        /// </summary>
        public MigrateState TableStruct { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        public MigrateState Storage { get; set; }

        /// <summary>
        /// 约束状态
        /// </summary>
        public MigrateState Constraint { get; set; }
    }

    /// <summary>
    /// 迁移状态
    /// </summary>
    public enum MigrateState
    {
        /// <summary>
        /// 未执行
        /// </summary>
        Todo,

        /// <summary>
        /// 不需要迁移
        /// </summary>
        Ignore,

        /// <summary>
        /// 迁移完成
        /// </summary>
        Finished
    }
}
