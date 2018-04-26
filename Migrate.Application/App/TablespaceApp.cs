using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;

namespace Migrate.Application.App
{
    /// <summary>
    /// 表空间应用类
    /// </summary>
    public class TablespaceApp
    {
        public void Create(ConnectString connString,Domain.Model.Tablespace space)
        {
            Tablespaces.CreateTablespace(connString, space);
        }

        /// <summary>
        /// 获取默认表空间
        /// </summary>
        /// <param name="connString"></param>
        //public void GetDefault(ConnectString connString)
        //{
        //    //TODO: 在展示层不要直接调用dal层
        //    string sql = "select * from user_tablespaces";
        //    DataGateway.ExecuteQuery(connString, sql);
        //}

        /// <summary>
        /// 获取临时表空间
        /// </summary>
        /// <param name="connString"></param>
        //public void GetTemporary(ConnectString connString)
        //{
        //    //TODO: 在展示层不要直接调用dal层
        //    string sql = "select * from user_tablespaces";
        //    DataGateway.ExecuteQuery(connString,sql);
        //}


        public void Drop(ConnectString connString, string  spaceName)
        {
            try
            {
                Tablespaces.DropTablespace(connString, spaceName);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取表空间信息
        /// </summary>
        /// <param name="connString"></param>
        public IEnumerable<Tablespace> GetAllTableSpaces(ConnectString connString)
        {
            return Tablespaces.GetTableSpaces(connString);
        }
    }
}
