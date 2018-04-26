using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Migrate.Domain.Helper.Access
{
    /// <summary>
    /// 采用的驱动程序是Oracle.ManagedDataAccess;不支持Clob字段。
    /// </summary>
    public class ManagedOraDbAccess : OracleDbAccess
    {
        public ManagedOraDbAccess(ConnectString connString) : base(connString)
        {

        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public override IDbConnection GetConnection()
        {
            if (ConnectString == null)
            {
                throw new Exception("没有配置连接字符串对象ConnectString");
            }
            string connectionString = $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={ConnectString.Host})(PORT={ConnectString.Port})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={ConnectString.Instance})));User Id={ConnectString.UserId};Password={ConnectString.Password};";

            if (ConnectString.IsDBA)
            {
                connectionString += "DBA Privilege=SYSDBA;";
            }

            return new OracleConnection(connectionString);
        }

        public override IDbDataParameter MakeIn(string name, object value)
        {

            var p = new OracleParameter(name, GetDbType(value));
            if (value is bool)
            {
                p.Value = Convert.ToInt16(value);
            }
            else
            {
                p.Value = value;
            }
            if (value is Array)
            {
                p.Size = (value as Array).Length;
            }
            return p;
        }

        public DbType GetDbType(object value)
        {
            if (value == null)
            {
                return DbType.String;
            }
            String type = value.GetType().ToString();
            if (value is Int16)
            {
                return DbType.Int16;
            }
            else if (value is Int32)
            {
                return DbType.Int32;
            }
            else if (value is Int64)
            {
                return DbType.Int64;
            }
            else if (value is Decimal)
            {
                return DbType.Decimal;
            }
            else if (value is Double)
            {
                return DbType.Double;
            }
            else if (value is DateTime)
            {
                return DbType.Date;
            }
            else if (value is float)
            {
                return DbType.Single;
            }
            else if (value is byte[])
            {
                return DbType.String;
            }
            //renzhsh
            //当string长度超过3700时，会报ora-1461错误。
            else if (value is char[] || (value is string && string.Format("{0}", value).Length > 3500))
            {
                return DbType.String;
            }
            else
            {
                return DbType.String;
            }
        }
    }
}
