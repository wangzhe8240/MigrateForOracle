using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper;
using Migrate.Domain.Helper.Access;
using System.Data.OracleClient;

namespace Migrate.Application.App
{

    public class LoginApp
    {

        public DataGateway gateway = new DataGateway(OracleProvider.ManagedDataAccess);

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="connectstring"></param>
        public void TestConnection(ConnectString connectstring)
        {

            string sql = "select 1 from dual";
            gateway.ExecuteScalar(connectstring, sql);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="connect"></param>
        public void LoginConnection(ConnectString connect)
        {
            string sql = "select 1 from dual";
            gateway.ExecuteScalar(connect, sql);

        }

    }
}
