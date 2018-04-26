using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Helper;
using Migrate.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Migrate.UnitTest.Domain.Helper
{
    [TestClass]
    public class ConstraintTest : BaseTest
    {
        [TestMethod]
        public void Test_GetConstraints()
        {
            IEnumerable<Constraint> list = Constraints.GetConstraints(ConnString, "SYS_USER");

            Assert.IsTrue(list.Count() > 0);

            foreach (var con in list)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(con.Columns));
                if (con.Type == "R")
                {
                    Assert.IsNotNull(con.RefConstraint);
                }
            }
        }

        [TestMethod]
        public void Test_GetOwnerConstraints()
        {
            IEnumerable<Constraint> list = Constraints.GetOwnerConstraints(ConnString);

            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void Test_GetByName()
        {
            string[] list = new string[] { "PK_SYS_USER", "UQ_SYS_USER_1", "FK_SYS_USER_ORGAN" };

            foreach (var name in list)
            {
                Constraint con = Constraints.GetConstraintDetail(ConnString, name);
                Assert.IsNotNull(con);
                Assert.IsTrue(!string.IsNullOrEmpty(con.Columns));
                if (con.Type == "R")
                {
                    Assert.IsNotNull(con.RefConstraint);
                }
            }
        }
    }
}
