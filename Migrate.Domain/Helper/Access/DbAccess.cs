using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Transactions;

namespace Migrate.Domain.Helper.Access
{
    public abstract class DbAccess
    {
        public DbAccess(ConnectString connString)
        {
            ConnectString = connString;
        }
        /// <summary>
        /// 连接字符串对象
        /// </summary>
        public ConnectString ConnectString { get; private set; }

        /// <summary>
        /// 数据库命令参数前缀(如SqlServer数据库为@)
        /// </summary>
        public abstract string ParameterPrefix { get; }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public abstract IDbConnection GetConnection();

        public abstract IDbDataParameter MakeIn(string name, object value);

        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDbDataParameter[] commandParameters)
        {
            IDbConnection connection = GetConnection();

            using (IDbCommand command = CreateCommand(connection, commandType, commandText, commandParameters))
            {
                try
                {
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExecuteTransaction(List<string> commands)
        {
            IDbConnection connection = GetConnection();

            connection.Open();

            IDbTransaction trans = connection.BeginTransaction();

            try
            {
                foreach (var sql in commands)
                {
                    using (IDbCommand cmd = CreateCommand(connection, CommandType.Text, sql))
                    {
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void ExecuteTransaction(List<DataCommandFilter> filters)
        {
            IDbConnection connection = GetConnection();

            connection.Open();

            IDbTransaction trans = connection.BeginTransaction();

            try
            {
                foreach (var filter in filters)
                {
                    using (IDbCommand cmd = CreateCommand(connection, CommandType.Text, filter.CommandText, filter.Params))
                    {
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public IDataReader ExecuteReader(string commandText, CommandType commandType, params IDbDataParameter[] commandParameters)
        {
            IDbConnection connection = GetConnection();

            using (IDbCommand command = CreateCommand(connection, commandType, commandText, commandParameters))
            {
                try
                {
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public object ExecuteScalar(string commandText, CommandType commandType, params IDbDataParameter[] commandParameters)
        {
            IDbConnection connection = GetConnection();

            using (IDbCommand command = CreateCommand(connection, commandType, commandText, commandParameters))
            {
                try
                {
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataCommandFilter CreateCommandFilter(string sql, params object[] args)
        {
            String sqlHashCode = sql.GetHashCode().ToString().Replace("-", "A");
            int argsLength = args.Length;
            Regex regex = new Regex(@"{\d+}", RegexOptions.IgnoreCase);
            Dictionary<String, object> myParams = new Dictionary<String, object>();
            var match = regex.Matches(sql);
            if (match.Count > 0)
            {

                if (args != null && argsLength > 0)
                {
                    List<String> argNames = new List<string>();
                    object[] matchArgs = null;

                    if (match.Count == 1 && argsLength > 1)
                    {
                        matchArgs = args;
                        argsLength = 1;
                    }
                    //遍历参数
                    for (int i = 0; i < argsLength; i++)
                    {
                        //生成SQL参数名称
                        String argName = String.Format("{0}parm_{1}{2}", this.ParameterPrefix, sqlHashCode, i);
                        argNames.Add(argName);
                        myParams.Add(argName, args[i]);
                    }
                    Regex myRegex = new Regex(@"((?<='{\d})')|('(?={\d+}'))", RegexOptions.IgnoreCase);
                    sql = myRegex.Replace(sql, "");
                    if (argNames != null && argNames.Count > 0)
                    {
                        sql = String.Format(sql, argNames.ToArray());
                    }
                    else
                    {
                        sql = String.Format(sql, argNames);
                    }
                }
            }
            return new DataCommandFilter()
            {
                CommandText = sql,
                Params = CreateDataParameters(myParams)
            };
        }

        protected IDbCommand CreateCommand(IDbConnection conn, CommandType commandType, string commandText, IDataParameter[] commandParameters = null)
        {
            IDbCommand command = conn.CreateCommand();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            command.CommandText = commandText;
            command.CommandType = commandType;

            if (commandParameters != null && commandParameters.Length > 0)
            {
                foreach (IDataParameter p in commandParameters)
                {
                    if (p != null && (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    command.Parameters.Add(p);
                }
            }

            return command;
        }

        protected IDbDataParameter[] CreateDataParameters(IDictionary<string, object> paramDict)
        {
            List<IDbDataParameter> list = new List<IDbDataParameter>();
            foreach (string key in paramDict.Keys)
            {
                list.Add(MakeIn(key, paramDict[key]));
            }
            return list.ToArray();
        }
    }
}
