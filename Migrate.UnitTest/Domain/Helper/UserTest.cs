using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Helper;
using Migrate.Domain.Model;
using System.Diagnostics;
using System.IO;

namespace Migrate.UnitTest.Domain.Helper
{
    [TestClass]
    public class UserTest : BaseTest
    {
        [TestMethod]
        public void Test_IsExists()
        {
            Assert.IsTrue(Users.IsExists(ConnString, "sys"));
            Assert.IsFalse(Users.IsExists(ConnString, "sys111"));
        }

        [TestMethod]
        public void Test_CreateUser()
        {
            User user = new User
            {
                Name = "plangis4",
                Password = "plangis4",
                DefaultTablespace = "plangis4",
                TempTablespace = "temp"
            };

            Assert.IsFalse(Users.IsExists(ConnString, "plangis4"), "用户plangis4已存在");
            Users.CreateUser(ConnString, user);
            Assert.IsTrue(Users.IsExists(ConnString, "plangis4"), "用户plangis4创建失败");
        }

        [TestMethod]
        public void Test_Grant()
        {
            Users.Grant(ConnString, "plangis4", new string[] { "CONNECT", "RESOURCE","DBA" });
        }
    }
}
