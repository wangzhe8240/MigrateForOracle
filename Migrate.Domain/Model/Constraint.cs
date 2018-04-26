using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper.Adapter;

namespace Migrate.Domain.Model
{
    [Serializable]
    public class Constraint
    {
        /// <summary>
        /// 表空间
        /// </summary>
        [Property(Field = "OWNER")]
        public string Tablespace { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        [Property(Field = "TABLE_NAME")]
        public string TableName { get; set; }

        /// <summary>
        /// 约束名称
        /// </summary>
        [Property(Field = "CONSTRAINT_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 约束类型
        /// <para>P:主键约束 R:参照约束 U:唯一性约束 C:非空约束</para>
        /// </summary>
        [Property(Field = "CONSTRAINT_TYPE")]
        public string Type { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        [Property(Field = "COLUMN_NAME")]
        public string Columns { get; set; }

        /// <summary>
        /// 约束类型R为时的约束名称
        /// </summary>
        [Property(Field = "R_CONSTRAINT_NAME")]
        public string RefName { get; set; }

        /// <summary>
        /// 约束类型R为时的参照约束
        /// </summary>
        public ConstraintColumns RefConstraint { get; set; }

        /// <summary>
        /// 约束类型R为时的删除规则
        /// <para>No Action, Set Null, Cascade</para>
        /// </summary>
        [Property(Field = "DELETE_RULE")]
        public string DeleteRule { get; set; }

        /// <summary>
        /// 有效性
        /// </summary>
        [Property(Field = "ENABLED")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 使用索引
        /// </summary>
        [Property(Field = "USING_INDEX")]
        public bool UsingIndex { get; set; }
    }

    /// <summary>
    /// 约束与列在数据库中的关系表
    /// </summary>
    [Serializable]
    public class ConstraintColumns
    {
        /// <summary>
        /// 表空间
        /// </summary>
        [Property(Field = "OWNER")]
        public string Owner { get; set; }

        /// <summary>
        /// 约束名
        /// </summary>
        [Property(Field = "CONSTRAINT_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Property(Field = "TABLE_NAME")]
        public string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [Property(Field = "COLUMN_NAME")]
        public string ColumnName { get; set; }

        [Property(Field = "POSITION")]
        public int Position { get; set; }
    }
}
