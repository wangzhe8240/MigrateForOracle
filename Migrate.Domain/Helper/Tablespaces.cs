using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper.Access;
using System.IO;
using System.Diagnostics;
using Migrate.Domain.Model;

namespace Migrate.Domain.Helper
{
    /// <summary>
    /// 表空间工具类
    /// </summary>
    public class Tablespaces
    {
        /// <summary>
        /// 获取表空间文件的存储目录
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static string GetStorePath(ConnectString connString)
        {
            string sql = "select name from v$datafile";
            string filePath = (string)new DataGateway(OracleProvider.ManagedDataAccess).ExecuteScalar(connString, sql);
            return Path.GetDirectoryName(filePath);
        }

        /// <summary>
        /// 表空间是否存在
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tablespaceName"></param>
        /// <returns></returns>
        public static bool IsExists(ConnectString connString, string tablespaceName)
        {
            string sql = $"select 1 from dba_tablespaces where Tablespace_name='{tablespaceName.ToUpper()}'";

            object result = new DataGateway(OracleProvider.ManagedDataAccess).ExecuteScalar(connString, sql);

            return result != null && Convert.ToInt16(result) == 1;
        }

        /// <summary>
        /// 创建表空间
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="space"></param>
        public static void CreateTablespace(ConnectString connString, Model.Tablespace space)
        {
            string sql = $"create tablespace {space.Name} logging datafile '{space.Path}' "
                    + $"size {space.Size}m "
                    + string.Format(space.AutoExtend ? "autoextend on next {0}m " : "autoextend off ", space.ExtendSize)
                    + $"maxsize {space.MaxSize}m "
                    + $"extent management local";

            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 删除表空间
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="spaceName"></param>
        /// <param name="dropDataFiles">是否删除数据文件</param>
        public static void DropTablespace(ConnectString connString, string spaceName, bool dropDataFiles = true)
        {
            string sql = $"drop tablespace {spaceName}";
            if (dropDataFiles)
            {
                sql += " including contents and datafiles";
            }
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 获取某表空间的相关信息（数据文件大小，名称）
        /// </summary>
        /// <param name="connstring"></param>
        /// <returns></returns>
        public static IEnumerable<Tablespace> GetTableSpacesInfo(ConnectString connstring, string tablespaceName)
        {
            string sql = "SELECT DISTINCT b.file_name ,a.INITIAL_EXTENT , b.AUTOEXTENSIBLE ,b.bytes,b.INCREMENT_BY ,b.MAXBYTES from DBA_DATA_FILES b, dba_tablespaces a "
            + $"where a.tablespace_name = b.tablespace_name and a.TABLESPACE_NAME = '{tablespaceName}'";
            Debug.WriteLine(sql);
            return new DataGateway(OracleProvider.ManagedDataAccess).Query<Tablespace>(connstring, sql);
        }


        public static IEnumerable<Tablespace> GetTableSpaces(ConnectString connstring)
        {
            string sql = "SELECT DISTINCT a.TABLESPACE_NAME,b.FILE_NAME, b.bytes,b.AUTOEXTENSIBLE ,b.INCREMENT_BY ,b.MAXBYTES from DBA_DATA_FILES b, dba_tablespaces a where a.tablespace_name = b.tablespace_name";
            Debug.WriteLine(sql);
            return new DataGateway(OracleProvider.ManagedDataAccess).Query<Tablespace>(connstring, sql);
        }
    }
}
