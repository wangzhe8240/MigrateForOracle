using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Migrate.Domain.Helper.Access
{
    public abstract class OracleDbAccess : DbAccess
    {
        public OracleDbAccess(ConnectString connString) : base(connString)
        {

        }

        /// <summary>
        /// 数据库命令参数前缀(如SqlServer数据库为@)
        /// </summary>
        public override string ParameterPrefix
        {
            get
            {
                return ":";
            }
        }
    }
}
