using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart.FileIO;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Migrate.UnitTest.FileIO
{
    [TestClass]
    public class WriterTest
    {
        [TestMethod]
        public void Test_Writer()
        {
            Writer w = new Writer(@"F:\FileIOTest\abc.t");
            w.Commit();
        }

        [TestMethod]
        public void Test_Partial()
        {
            Writer w = new Writer(@"F:\FileIOTest\test.mig");

            PartialWriter pw = w.CreatePartial("student", "学生信息");

            List<Student> list = new List<Student>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new Student());
            }

            pw.Append(typeof(Student).Name, list);

            pw.Commit();

            pw = w.CreatePartial("students", "aaa");
            for (int i = 0; i < 1000; i++)
            {
                pw.Append($"student_{i}", new Student());
            }
            pw.Commit();

            w.Commit();
        }
    }

    [Serializable]
    public class Student
    {
        public Student()
        {
            Name = "1";
            Age = 1;
            Address = "1";
            Photo = 1;
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int Photo { get; set; }
    }
}
