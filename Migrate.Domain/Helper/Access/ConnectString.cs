using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Helper.Access
{
    /// <summary>
    /// 数据库联接字符串
    /// </summary>
    public class ConnectString
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 服务实例
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// 以DBA权限连接
        /// </summary>
        public bool IsDBA { get; set; }

        public override int GetHashCode()
        {
            return Host.GetHashCode() & Port.GetHashCode() & UserId.GetHashCode();
        }
    }
}
