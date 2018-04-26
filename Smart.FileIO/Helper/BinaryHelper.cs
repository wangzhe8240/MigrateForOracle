using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Smart.FileIO
{
    public class BinaryHelper
    {
        /// <summary>
        /// 将对象序列化为byte[]
        /// </summary>
        /// <param name="model">需要序列化的对象</param>
        /// <returns>序列化获取的二进制流</returns>
        public static byte[] Serialize(object model)
        {
            byte[] buff;
            try
            {
                using (var ms = new MemoryStream())
                {
                    IFormatter iFormatter = new BinaryFormatter();
                    iFormatter.Serialize(ms, model);
                    buff = ms.GetBuffer();
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return buff;
        }


        /// <summary>
        /// 将byte[]反序列化为对象
        /// 使用IFormatter的Deserialize发序列化
        /// </summary>
        /// <param name="buff">传入的byte[]</param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] buff) where T : class
        {
            return Deserialize(buff) as T;
        }

        public static object Deserialize(byte[] buff)
        {
            object obj;
            try
            {
                using (var ms = new MemoryStream(buff))
                {
                    IFormatter iFormatter = new BinaryFormatter();
                    obj = iFormatter.Deserialize(ms);
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return obj;
        }
    }
}
