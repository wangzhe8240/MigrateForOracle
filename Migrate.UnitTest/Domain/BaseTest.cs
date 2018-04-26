using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Helper.Access;

namespace Migrate.UnitTest.Domain
{
    public class BaseTest
    {
        /// <summary>
        /// scott 联接字符串
        /// </summary>
        protected ConnectString ConnString { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ConnString = new ConnectString
            {
                Host = "localhost",
                Instance = "orcl",
                Port = "1521",
                UserId = "plangis3",
                Password = "plangis3",
                IsDBA = false
            };
        }
    }
}
