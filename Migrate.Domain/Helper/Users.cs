using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Model;
using Migrate.Domain.Helper.Access;
using System.Diagnostics;

namespace Migrate.Domain.Helper
{
    public class Users
    {
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsExists(ConnectString connString, string userName)
        {
            string sql = $"select 1 from all_users where username='{userName.ToUpper()}'";

            object result = new DataGateway(OracleProvider.ManagedDataAccess).ExecuteScalar(connString, sql);

            return result != null && Convert.ToInt16(result) == 1;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="user"></param>
        public static void CreateUser(ConnectString connString, User user)
        {
            string sql = $"CREATE USER {user.Name} IDENTIFIED BY {user.Password} ACCOUNT UNLOCK DEFAULT TABLESPACE {user.DefaultTablespace} TEMPORARY TABLESPACE {user.TempTablespace}";

            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="userName"></param>
        public static void DropUser(ConnectString connString, string userName)
        {
            string sql = $"drop user {userName} cascade";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 用户授权
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="userName"></param>
        /// <param name="roles"></param>
        public static void Grant(ConnectString connString, string userName, string[] roles)
        {
            string joinedRole = string.Join(",", roles);
            string sql = $"GRANT {joinedRole} TO {userName}";

            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        public static IEnumerable<User> GetAllUser(ConnectString connString)
        {
            string sql = "SELECT username,password,default_tablespace,TEMPORARY_TABLESPACE FROM dba_users";
            Debug.WriteLine(sql);
            return new DataGateway(OracleProvider.ManagedDataAccess).Query<User>(connString, sql);
        }
    }
}
