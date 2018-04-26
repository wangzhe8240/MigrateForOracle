using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart.FileIO;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Migrate.UnitTest.FileIO
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void TestReader()
        {
            Reader r = new Reader(@"F:\FileIOTest\test.mig");

            using (PartialReader pr = r.ReadPartial(r.Header["student"]))
            {
                List<Student> list = pr.Read<List<Student>>(pr.Header[0]);
            }
            using (PartialReader pr = r.ReadPartial(r.Header["students"]))
            {
                for (int i = 0; i < 10; i++)
                {
                    Student stu = pr.Read<Student>(pr.Header[$"student_{i * 111}"]);
                    Assert.IsNotNull(stu);
                }
            }
        }

        [TestMethod]
        public void TestReader_Dispose()
        {
            Reader r = new Reader(@"F:\FileIOTest\test.mig");

            PartialReader pr = r.ReadPartial(r.Header["student"]);
            List<Student> list = pr.Read<List<Student>>(pr.Header[0]);

            pr = r.ReadPartial(r.Header["students"]);
            for (int i = 0; i < 10; i++)
            {
                Student stu = pr.Read<Student>(pr.Header[$"student_{i * 111}"]);
                Assert.IsNotNull(stu);
            }
        }
    }
}
