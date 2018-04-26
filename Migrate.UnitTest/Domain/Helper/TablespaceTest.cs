using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Helper;
using Migrate.Domain.Model;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Migrate.UnitTest.Domain.Helper
{
    [TestClass]
    public class TablespaceTest : BaseTest
    {
        [TestMethod]
        public void Test_GetStorePath()
        {
            string path = Tablespaces.GetStorePath(ConnString);
            Debug.WriteLine(path);
        }

        [TestMethod]
        public void Test_IsExists()
        {
            Assert.IsTrue(Tablespaces.IsExists(ConnString, "temp"), "temp不存在");
            Assert.IsFalse(Tablespaces.IsExists(ConnString, "temp1"), "temp1存在");
        }

        [TestMethod]
        public void Test_CreateTablespace()
        {
            Tablespace space = new Tablespace
            {
                Name = "plangis4",
                Path = Path.Combine(@"D:\APP\ADMINISTRATOR\ORADATA\ORCL", "plangis4.dbf"),
                Size = 10,
                AutoExtend = true,
                ExtendSize = 1,
                MaxSize = 100
            };

            Assert.IsFalse(Tablespaces.IsExists(ConnString, "plangis4"), "表空间plangis4已经存在");

            Tablespaces.CreateTablespace(ConnString, space);
            Assert.IsTrue(Tablespaces.IsExists(ConnString, "plangis4"), "表空间plangis4创建失败");
        }

        [TestMethod]
        public void Test_DropTablespace()
        {
            Assert.IsTrue(Tablespaces.IsExists(ConnString, "uc"), "表空间uc不存在");

            Tablespaces.DropTablespace(ConnString, "uc");

            Assert.IsFalse(Tablespaces.IsExists(ConnString, "uc"), "表空间uc删除失败");
        }
    }
}
