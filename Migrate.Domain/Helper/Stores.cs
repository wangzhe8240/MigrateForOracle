using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;

namespace Migrate.Domain.Helper
{
    /// <summary>
    /// 数据迁移工具类
    /// </summary>
    public class Stores
    {
        /// <summary>
        /// 从数据库中读取数据
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IDataReader Read(ConnectString connString, string tableName)
        {
            return new DataGateway().ExecuteQuery(connString, $"select * from {tableName}");
        }

        /// <summary>
        /// 查询数据的行数
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static int Count(ConnectString connString, string tableName)
        {
            return Convert.ToInt32(new DataGateway().ExecuteScalar(connString, $"select count(1) from {tableName}"));
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IDataReader ReadPage(ConnectString connString, string tableName, int start = 1, int length = 100)
        {
            return new DataGateway().ExecuteQuery(connString, $"select * from (select rownum rn, t.* from {tableName} t) where rn between {start} and {start + length - 1}");
        }

        /// <summary>
        /// 将数据写入到数据库
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="dataSet"></param>
        public static void Write(ConnectString connString, MDataSet dataSet)
        {
            new DataGateway().BatchInsert(connString, dataSet);
        }
    }
}
