using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Model
{
    /// <summary>
    /// Oracle 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 默认表空间
        /// </summary>
        public string DefaultTablespace { get; set; }

        /// <summary>
        /// 临时表空间
        /// </summary>
        public string TempTablespace { get; set; }
    }
}
