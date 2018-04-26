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
    /// 约束工具类
    /// </summary>
    public class Constraints
    {
        /// <summary>
        /// 创建约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cons"></param>
        public static void CreateConstraints(ConnectString connString, Constraint cons)
        {
            string sql = $"alter table {cons.TableName} add constraint {cons.Name} ";
            switch (cons.Type)
            {
                case "P":
                case "U":
                    string key = cons.Type == "P" ? "primary key" : "unique";
                    sql += $"{key} ({cons.Columns}) ";

                    if (cons.UsingIndex)
                    {
                        sql += $"using index tablespace {cons.Tablespace} " +
                            $"pctfree 10 initrans 2 maxtrans 255 storage(initial 64K next 1M minextents 1 maxextents unlimited)";
                    }

                    break;
                case "R":
                    sql += $"foreign key ({cons.Columns}) references {cons.RefConstraint.TableName} ({cons.RefConstraint.ColumnName}) on delete {cons.DeleteRule}";
                    break;
            }

            Debug.WriteLine(sql);

            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 获取表的约束信息
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IEnumerable<Constraint> GetConstraints(ConnectString connString, string tableName)
        {
            DataGateway gateway = new DataGateway(OracleProvider.ManagedDataAccess);

            string sql = "select owner, constraint_name, constraint_type, TABLE_NAME, r_constraint_name, delete_rule, "
                    + "case when (status='ENABLED') then 1 else 0 end as enabled, "
                    + "case when (index_name is not null) then 1 else 0 end as using_index "
                    + $"from user_constraints where constraint_type!='C' and table_name='{tableName}'";

            IEnumerable<Constraint> result = gateway.Query<Constraint>(connString, sql);

            sql = $"select * from USER_CONS_COLUMNS where table_name='{tableName}' order by column_name,position";

            IEnumerable<ConstraintColumns> cols = gateway.Query<ConstraintColumns>(connString, sql);

            foreach (var con in result)
            {
                con.Columns = string.Join(",", cols.Where(item => item.Name == con.Name).OrderBy(item => item.Position).Select(item => item.ColumnName));

                if (con.Type == "R")
                {
                    con.RefConstraint = gateway.Query<ConstraintColumns>(connString, $"select * from USER_CONS_COLUMNS where constraint_name='{con.RefName}'").FirstOrDefault();
                }
            }

            return result;
        }

        /// <summary>
        /// 获取当前表空间下的所有约束信息
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static IEnumerable<Constraint> GetOwnerConstraints(ConnectString connString)
        {
            string sql = "select owner, constraint_name, constraint_type, TABLE_NAME "
                    + $"from user_constraints where constraint_type!='C'";

            return new DataGateway(OracleProvider.ManagedDataAccess).Query<Constraint>(connString, sql);
        }

        /// <summary>
        /// 获取约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="name">约束名</param>
        /// <returns></returns>
        public static Constraint GetConstraintDetail(ConnectString connString, string name)
        {
            DataGateway gateway = new DataGateway(OracleProvider.ManagedDataAccess);

            string sql = "select owner, constraint_name, constraint_type, TABLE_NAME, r_constraint_name, delete_rule, "
                    + "case when (status='ENABLED') then 1 else 0 end as enabled, "
                    + "case when (index_name is not null) then 1 else 0 end as using_index "
                    + $"from user_constraints where constraint_name='{name}'";

            IEnumerable<Constraint> result = gateway.Query<Constraint>(connString, sql);

            sql = $"select * from USER_CONS_COLUMNS where CONSTRAINT_NAME='{name}' order by TABLE_NAME,column_name,position";

            IEnumerable<ConstraintColumns> cols = gateway.Query<ConstraintColumns>(connString, sql);

            foreach (var con in result)
            {
                con.Columns = string.Join(",", cols.Where(item => item.Name == con.Name).OrderBy(item => item.Position).Select(item => item.ColumnName));

                if (con.Type == "R")
                {
                    con.RefConstraint = gateway.Query<ConstraintColumns>(connString, $"select * from USER_CONS_COLUMNS where constraint_name='{con.RefName}'").FirstOrDefault();
                }
            }

            return result.FirstOrDefault();
        }
        /// <summary>
        /// 删除约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="table">表名</param>
        /// <param name="constraint">约束名</param>
        public static void DropConstraint(ConnectString connString, string table, string constraint)
        {
            string sql = $"alter table {table} drop constraint {constraint}";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql);
        }

        /// <summary>
        /// 删除约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cons"></param>
        public static void DropConstraint(ConnectString connString, Constraint cons)
        {
            DropConstraint(connString, cons.TableName, cons.Name);
        }

        /// <summary>
        /// 禁用约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="table">表名</param>
        /// <param name="constraint">约束名</param>
        public static void DisableConstraint(ConnectString connString, string table, string constraint)
        {
            string sql = $"alter table {table} disable constraint {constraint}";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 禁用约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cons"></param>
        public static void DisableConstraint(ConnectString connString, Constraint cons)
        {
            DisableConstraint(connString, cons.TableName, cons.Name);
        }

        /// <summary>
        /// 启用约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="table"></param>
        /// <param name="constraint"></param>
        public static void EnableConstraint(ConnectString connString, string table, string constraint)
        {
            string sql = $"alter table {table} enable constraint {constraint}";
            new DataGateway(OracleProvider.ManagedDataAccess).ExecuteNonQuery(connString, sql.Trim());
        }

        /// <summary>
        /// 启用约束
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cons"></param>
        public static void EnableConstraint(ConnectString connString, Constraint cons)
        {
            EnableConstraint(connString, cons.TableName, cons.Name);
        }
    }
}

