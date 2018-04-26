using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Smart.FileIO
{
    /// <summary>
    /// MD5摘要算法
    /// </summary>
    public class MD5Helper
    {
        public static string ComputeHash(string myString)
        {
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);

            return ComputeHash(fromData);
        }

        public static string ComputeHash(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(data);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }

        public static string ComputeHash(Stream input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(input);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;

        }
    }
}
