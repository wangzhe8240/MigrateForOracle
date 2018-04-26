using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Clients
{
    /// <summary>
    /// 全局上下文
    /// </summary>
    public class Context
    {
        public static Migrate.Domain.Helper.Access.ConnectString connString { get; set; }
        public static Migrate.Domain.Model.User user { get; set; }
        public static string UserName { get; set; }
        //public static string TableName { get; set; }

    }
}
