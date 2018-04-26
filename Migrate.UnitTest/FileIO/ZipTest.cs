using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Migrate.UnitTest.FileIO
{
    [TestClass]
    public class ZipTest
    {
        [TestMethod]
        public void TestZip()
        {
            string dir = @"F:\FileIOTest\";
            string[] fileList = new string[]
            {
                dir+"1规划区范围图.dwg",
                dir+"2空间管制分区.dwg",
                dir+"3城市增长边界图.dwg",
                dir+"4中心城用地规划图.dwg",
                dir+"5公共服务设施规划图.dwg",
                dir+"6市域空间管制规划图.dwg",
                dir+"7绿线.dwg",
                dir+"8蓝线.dwg",
                dir+"9黄线.dwg",
                dir+"10紫线.dwg",
                dir+"现行总规.dwg",
            };

            Smart.FileIO.ZipHelper.Zip(fileList, dir + "测试数据.zip");
        }

        [TestMethod]
        public void TestUnZip()
        {
            Smart.FileIO.ZipHelper.UnZip(@"F:\FileIOTest\Test\测试数据.zip.mig");
        }
    }
}
