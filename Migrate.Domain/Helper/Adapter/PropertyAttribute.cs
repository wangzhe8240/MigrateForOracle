using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Helper.Adapter
{
    /// <summary>
    /// Property特性，与数据库字段关联
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropertyAttribute : Attribute
    {
        /// <summary>
        /// 数据库字段名
        /// </summary>
        public string Field { get; set; }
    }
}
