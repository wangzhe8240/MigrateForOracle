using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Migrate.Domain.Helper.Access
{
    /// <summary>
    /// 数据集
    /// </summary>
    [Serializable]
    public class MDataSet : List<MDataUnit>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dr"></param>
        public MDataSet(string table, string[] fields)
        {
            Table = table;
            Fields = fields;
        }

        /// <summary>
        /// 表名称
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// 数据集的字段
        /// </summary>
        public string[] Fields { get; private set; }

        private string _cmd = "";

        public string CommandText
        {
            get
            {
                if (string.IsNullOrEmpty(_cmd))
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < Fields.Length; i++)
                    {
                        list.Add("{" + i + "}");
                    }

                    _cmd = $"insert into {Table}({string.Join(",", Fields.Select(item => item.Trim()))}) " +
                        $"values({string.Join(",", list.Select(item => item.Trim()))})";
                }
                return _cmd;
            }
        }

        public void SetDataSource(IDataReader dr)
        {
            try
            {
                Clear();
                while (dr.Read())
                {
                    MDataUnit unit = new MDataUnit();
                    foreach (var field in Fields)
                    {
                        unit.Add(field, dr[field]);
                    }
                    Add(unit);
                }

                if (!dr.IsClosed) dr.Close();
            }
            // 捕获 dr 不存在 Field 的异常
            catch (KeyNotFoundException) { }
            catch (IndexOutOfRangeException) { }
        }

        public object[] CreateParams(MDataUnit unit)
        {
            List<object> list = new List<object>();
            foreach (var field in Fields)
            {
                list.Add(unit[field]);
            }
            return list.ToArray();
        }
    }

    /// <summary>
    /// 数据单元
    /// </summary>
    [Serializable]
    public class MDataUnit
    {
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        public object this[string key]
        {
            get
            {
                if (!dict.Keys.Contains(key))
                {
                    return null;
                }
                return dict[key];
            }
        }

        public void Add(string key, object value)
        {
            dict.Add(key, value);
        }
    }
}
