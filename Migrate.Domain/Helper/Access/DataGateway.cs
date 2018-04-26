using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Migrate.Domain.Helper.Adapter;

namespace Migrate.Domain.Helper.Access
{
    public class DataGateway
    {
        public DataGateway(OracleProvider provider = OracleProvider.OracleClient)
        {
            Provider = provider;
        }

        public OracleProvider Provider { get; private set; }

        protected DbAccess GetDbAccess(ConnectString connString)
        {
            DbAccess result = null;
            switch (Provider)
            {
                case OracleProvider.OracleClient:
                    result = new NativeOraDbAccess(connString);
                    break;
                case OracleProvider.ManagedDataAccess:
                    result = new ManagedOraDbAccess(connString);
                    break;
            }
            return result;
        }

        public int ExecuteNonQuery(ConnectString connString, string commandText, params object[] args)
        {
            DbAccess db = GetDbAccess(connString);
            DataCommandFilter filter = db.CreateCommandFilter(commandText, args);
            return db.ExecuteNonQuery(filter.CommandText, CommandType.Text, filter.Params);
        }

        public void ExecuteTransction(ConnectString connString, List<string> sqls)
        {
            DbAccess db = GetDbAccess(connString);
            db.ExecuteTransaction(sqls);
        }

        public void BatchInsert(ConnectString connString, MDataSet dataSet)
        {
            DbAccess db = GetDbAccess(connString);

            List<DataCommandFilter> list = new List<DataCommandFilter>();
            foreach (MDataUnit unit in dataSet)
            {
                list.Add(db.CreateCommandFilter(dataSet.CommandText, dataSet.CreateParams(unit)));
            }
            db.ExecuteTransaction(list);
        }

        public object ExecuteScalar(ConnectString connString, string commandText, params object[] args)
        {
            DbAccess db = GetDbAccess(connString);
            DataCommandFilter filter = db.CreateCommandFilter(commandText, args);
            return db.ExecuteScalar(filter.CommandText, CommandType.Text, filter.Params);
        }

        public IDataReader ExecuteQuery(ConnectString connString, string commandText, params object[] args)
        {
            DbAccess db = GetDbAccess(connString);
            DataCommandFilter filter = db.CreateCommandFilter(commandText, args);
            return db.ExecuteReader(filter.CommandText, CommandType.Text, filter.Params);
        }

        public IEnumerable<TModel> Query<TModel>(ConnectString connString, string commandText, params object[] args)
             where TModel : class, new()
        {
            return ExecuteQuery(connString, commandText, args).Adapter<TModel>();
        }
    }

    public enum OracleProvider
    {
        /// <summary>
        /// System.Data.OracleClient;不支持以DBA身份登录
        /// </summary>
        OracleClient,

        /// <summary>
        /// Oracle.ManagedDataAccess.Client;不支持Clob字段
        /// </summary>
        ManagedDataAccess
    }
}