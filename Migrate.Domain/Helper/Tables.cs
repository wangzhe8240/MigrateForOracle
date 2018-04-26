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
    /// <summary>
    /// 表工具类
    /// </summary>
    public class Tables
    {
        /// <summary>
        /// 判断表是否已存在
        /// </summary>
        /// <param name="connString">普通用户</param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool IsExists(ConnectString connString, string tableName)
        {
            string sql = $"select 1 from dba_tables where table_name = '{tableName}'";
            object result = new DataGateway(OracleProvider.ManagedDataAccess).ExecuteScalar(connString, sql);
            return result != null && Convert.ToInt16(result) == 1;
        }

        /// <summary>
        /// 获取当前表空间的所有表
        /// </summary>
        /// <param name="connString">普通用户</param>
        /// <returns></returns>
        public static IEnumerable<Table> GetOwnerTables(ConnectString connString)
        {
            string sql = "select t.object_id, t.OBJECT_NAME, p.tablespace_name, c.comments, t.created "
                + "from user_objects t, user_all_tables p, user_tab_comments c "
                + "where t.object_name= p.table_name and t.object_name= c.table_name "
                + "and t.object_type = 'TABLE'";

            return new DataGateway(OracleProvider.ManagedDataAccess).Query<Table>(connString, sql);
        }

        /// <summary>
        /// 获取表的详细信息（包括字段）
        /// </summary>
        /// <param name="connString">普通用户</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static Table GetTableDetails(ConnectString connString, string tableName)
        {
            string sql = "select t.object_id, t.OBJECT_NAME, p.tablespace_name, c.comments, t.created "
                + "from user_objects t, user_all_tables p, user_tab_comments c "
                + "where t.object_name= p.table_name and t.object_name= c.table_name "
                + $"and t.object_type = 'TABLE' and t.OBJECT_NAME = '{tableName}'";

            Debug.WriteLine(sql);

            Table result = new DataGateway(OracleProvider.ManagedDataAccess).Query<Table>(connString, sql).FirstOrDefault();
            if (result != null)
            {
                result.Columns = GetColumns(connString, tableName);
            }

            return result;
        }

        /// <summary>
        /// 获取表的字段信息
        /// </summary>
        /// <param name="connString">普通用户</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IEnumerable<Column> GetColumns(ConnectString connString, string tableName)
        {
            string sql = "select t.table_name, t.column_name, t.data_type, t.data_length, t.char_col_decl_length,t.data_precision, t.data_scale, t.data_default, c.comments, "
                  + "case when (t.nullable='Y') then 1 else 0 end as nullable, "
                  + "case when (cu.constraint_type='P') then 1 else 0 end as is_priamry_key "
                  + "from user_tab_columns t "
                  + "join user_col_comments c on t.table_name = c.table_name and t.column_name = c.column_name "
                  + "left join (select ucc.table_name,ucc.column_name,uc.constraint_type from user_cons_columns ucc "
                  + "join user_constraints uc on ucc.constraint_name = uc.constraint_name "
                  + $"where ucc.table_name='{tableName}' and uc.constraint_type='P') cu "
                  + "on t.column_name = cu.column_name "
                   + $"where t.table_name = '{tableName}' order by t.column_id";
            Debug.WriteLine(sql);

            return new DataGateway(OracleProvider.ManagedDataAccess).Query<Column>(connString, sql);
        }

        /// <summary>
        /// 根据表的基本信息和字段集合创建表
        /// </summary>
        /// <param name="connString">dba用户</param>
        /// <param name="table"></param>
        public static void CreateTable(ConnectString connString, Table table)
        {
            List<string> sqls = new List<string>();

            string colSql = string.Join(",", table.Columns.Select(item => CreateColumnSQL(item)));

            string sql = $"create Table {table.Name} ({colSql}) tablespace {table.TablespaceName} " +
             "pctfree 10 initrans 1 maxtrans 255 storage(initial 64K minextents 1 maxextents unlimited)";

            sqls.Add(sql);

            if (!string.IsNullOrEmpty(table.Comments))
            {
                sqls.Add($"comment on table {table.Name} is '{table.Comments}'");
            }

            foreach (var col in table.Columns)
            {
                if (!string.IsNullOrEmpty(col.Comments))
                {
                    sqls.Add($"comment on column {table.Name}.{col.Name} is '{col.Comments}'");
                }
            }

            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteTransction(connString, sqls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private static string CreateColumnSQL(Column column)
        {
            StringBuilder sql = new StringBuilder($"{column.Name} ");

            #region "DataType"
            switch (column.DataType)
            {
                case "DATE":
                case "CLOB":
                case "BLOB":
                case "LONG":
                case "NBLOB":
                case "LONG RAW":
                case "BINARY_FLOAT":
                case "BINARY_DOUBLE":
                case "INTERVAL YEAR(2) TO MONTH":
                case "INTERVAL DAY(2) TO SECOND(6)":
                case "TIMESTAMP(6) WITH TIME ZONE":
                case "TIMESTAMP(6) WITH LOCAL TIME ZONE":
                    sql.Append($"{column.DataType} ");
                    break;
                case "NUMBER":
                    if (column.DataPrecision > 0)
                    {
                        if (column.DataScale > 0)
                        {
                            sql.Append($"{column.DataType}({column.DataPrecision},{column.DataScale}) ");
                        }
                        else
                        {
                            sql.Append($"{column.DataType}({column.DataPrecision}) ");
                        }
                    }
                    else
                    {
                        sql.Append($"{column.DataType} ");
                    }
                    break;
                case "VARCHAR2":
                case "NVARCHAR2":
                case "CHAR":
                case "RAW":
                    sql.Append($"{column.DataType}({column.CharDeclLength}) ");
                    break;
                default:
                    throw new Exception($"未处理的数据类型：{column.DataType}");
            }
            #endregion

            if (!string.IsNullOrEmpty(column.DataDefault) && column.DataDefault.Trim() != "null")
            {
                sql.Append($"default {column.DataDefault.Trim()} ");
            }

            if (!column.AllowNull)
            {
                sql.Append("not null");
            }

            return sql.ToString();
        }

        /// <summary>
        /// 删除表，包括约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        public static void DropTable(ConnectString connString, string tableName)
        {
            // TODO: 与约束的关系没有处理
            string sql = $"drop table {tableName} cascade constraints";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 删除表的数据
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        public static void TruncateTable(ConnectString connString, string tableName)
        {
            string sql = $"truncate table {tableName}";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }
    }
}
