using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Model;
using Migrate.Domain.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Migrate.UnitTest.Domain.Helper
{
    [TestClass]
    public class TableTest : BaseTest
    {
        [TestMethod]
        public void Test_GetOwnerTables()
        {
            List<Table> list = Tables.GetOwnerTables(ConnString).ToList();

            Assert.IsTrue(list != null && list.Count > 0);
        }

        [TestMethod]
        public void Test_GetColumns()
        {
            List<Column> list = Tables.GetColumns(ConnString, "T_USER").ToList();

            Assert.IsTrue(list != null && list.Count > 0);

            foreach (var col in list)
            {
                Debug.WriteLine(col.DataDefault);
            }
        }

        [TestMethod]
        public void Test_GetTableDetails()
        {
            Table table = Tables.GetTableDetails(ConnString, "SYS_USER");

            Assert.IsNotNull(table);
            Assert.IsTrue(table.Columns.Count() > 0);
        }

        [TestMethod]
        public void Test_CreateTable()
        {
            Table table = Tables.GetTableDetails(ConnString, "T_USER");

            Assert.IsNotNull(table);

            table.Name = "T_USER_1";

            Tables.CreateTable(ConnString, table);

            Table tab= Tables.GetTableDetails(ConnString, "T_USER_1");

            Assert.IsNotNull(tab);
        }

        [TestMethod]
        public void Test_GetConstraints()
        {
            List<Constraint> list = Constraints.GetConstraints(ConnString, "SYS_USER").ToList();
            Assert.IsTrue(list != null && list.Count > 0);
        }

        /// <summary>
        /// 测试表是否存在
        /// </summary>
        [TestMethod]
        public void Test_IsExists()
        {
            Assert.IsFalse(Tables.IsExists(ConnString, "TAB_TEST"), "条件为true则测试成功，表存在");
            Assert.IsTrue(Tables.IsExists(ConnString, "SYS_USER"), "条件为false则测试成功，表不存在");
        }

    }
}
