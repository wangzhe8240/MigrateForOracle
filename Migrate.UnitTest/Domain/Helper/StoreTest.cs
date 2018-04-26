using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Migrate.Domain.Helper.Access;
using System.Collections;
using Migrate.Domain.Helper;
using Migrate.Domain.Model;
using System.Linq;
using System.IO;

namespace Migrate.UnitTest.Domain.Helper
{
    [TestClass]
    public class StoreTest : BaseTest
    {
        [TestMethod]
        public void Test_Insert()
        {
            String clobString = "";
            for (var i = 0; i < 400; i++)
            {
                clobString += "0123456789";
            }
            string sql = "insert into T_USER values({0},{1},{2},{3},{4},{5},{6})";
            new DataGateway().ExecuteNonQuery(ConnString, sql, "1", 2, 0.3, 0.4, 5, DateTime.Now, clobString);
        }

        [TestMethod]
        public void Test_Read()
        {
            Stores.Read(ConnString, "T_USER");
        }

        [TestMethod]
        public void Test_Write()
        {
            string tableName = "T_USER";

            Table tableDetail = Tables.GetTableDetails(ConnString, tableName);
            MDataSet dataSet = new MDataSet(tableDetail.Name, tableDetail.Columns.Select(item => item.Name).ToArray());

            dataSet.SetDataSource(Stores.Read(ConnString, tableName));

            dataSet.Table = "T_USER_1";

            Stores.Write(ConnString, dataSet);
        }

        [TestMethod]
        public void Test_Blob()
        {
            ConnectString source = new ConnectString
            {
                Host = "192.168.0.120",
                Port = "1521",
                Instance = "orcl",
                UserId = "masgh",
                Password = "masgh"
            };
            ConnectString dest = new ConnectString
            {
                Host = "192.168.0.205",
                Port = "1521",
                Instance = "orcl",
                UserId = "masgh",
                Password = "masgh"
            };

            string table = "T5399";

            Table tableDetail = Tables.GetTableDetails(source, table);
            MDataSet dataSet = new MDataSet(tableDetail.Name, tableDetail.Columns.Select(item => item.Name).ToArray());

            System.Data.IDataReader dr = Stores.Read(source, table);
            dataSet.SetDataSource(dr);
            Stores.Write(dest, dataSet);
        }

        [TestMethod]
        public void Insert_Blob()
        {
            ConnectString dest = new ConnectString
            {
                Host = "localhost",
                Port = "1521",
                Instance = "orcl",
                UserId = "uc",
                Password = "uc"
            };
            byte[] img = File.ReadAllBytes(@"F:\FileIOTest\IMG_20170729_131406.jpg");
            string sql = "insert into T_5399 values({0},{1})";

            new DataGateway().ExecuteNonQuery(dest, sql, "1", img);
        }
    }
}
