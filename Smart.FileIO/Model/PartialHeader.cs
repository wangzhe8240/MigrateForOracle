using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.FileIO.Model
{
    [Serializable]
    public class PartialHeader : List<DataEntry>
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 启用分页
        /// </summary>
        public bool EnablePage { get; internal set; }

        /// <summary>
        /// 单文件的最大Size。单位：M
        /// </summary>
        public int MaxSize { get; internal set; }

        public DataEntry this[string name]
        {
            get
            {
                DataEntry result = null;
                foreach (var item in this)
                {
                    if (item.Name == name)
                    {
                        result = item;
                        break;
                    }
                }
                if (result == null)
                {
                    throw new IndexOutOfRangeException($"不存在{name}");
                }
                return result;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{FileName}:{EnablePage}:{MaxSize};");
            foreach (var item in this)
            {
                sb.Append($"{item.ToString()};");
            }
            return sb.ToString();
        }
    }
}
