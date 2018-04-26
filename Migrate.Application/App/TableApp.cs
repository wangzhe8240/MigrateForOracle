using Migrate.Application.Model;
using Migrate.Domain.Helper;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Application.App
{
    /// <summary>
    /// 表应用类
    /// </summary>
    public class TableApp
    {
        public void Create(ConnectString connString, Table table)
        {
            Tables.CreateTable(connString, table);
        }

        public void Drop(ConnectString connString, string tableName)
        {
            Tables.DropTable(connString, tableName);
        }

        public void DropDate(ConnectString connString, string tableName)
        {
            Tables.TruncateTable(connString, tableName);
        }

        /// <summary>
        /// 获取某个表空间下的所有表
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tablespaceName"></param>
        public IEnumerable<Table> GetAlltable(ConnectString connString)
        {
            return Tables.GetOwnerTables(connString);
        }

        /// <summary>
        /// 获取导出表的配置信息
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public IEnumerable<TableProfile> Get(ConnectString connString)
        {
            IEnumerable<Table> list = Tables.GetOwnerTables(connString);
            IList<TableProfile> result = new List<TableProfile>();

            foreach (var t in list)
            {
                result.Add(new TableProfile()
                {
                    TableName = t.Name,
                    IncludeConstraint = true,
                    IncludeStorage = true
                });
            }

            return result;
        }

        /// <summary>
        /// 导出表
        /// </summary>
        public void Export(ConnectString connString, MigrateProfile profile)
        {
            MigrateService service = new D2DService(profile);
            service.Start();
        }

    }
}
