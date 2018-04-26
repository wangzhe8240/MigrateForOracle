using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper.Adapter;

namespace Migrate.Domain.Model
{
    [Serializable]
    public class Column
    {
        [Property(Field = "COLUMN_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [Property(Field = "DATA_TYPE")]
        public string DataType { get; set; }

        /// <summary>
        /// mandatory, Length of the column in bytes
        /// </summary>
        [Property(Field = "DATA_LENGTH")]
        public int DataLength { get; set; }

        /// <summary>
        /// Declaration length of character type column
        /// </summary>
        [Property(Field ="CHAR_COL_DECL_LENGTH")]
        public int CharDeclLength { get; set; }

        /// <summary>
        /// Length: decimal digits(NUMBER) or inary digits(FLOAT)
        /// </summary>
        [Property(Field = "DATA_PRECISION")]
        public int DataPrecision { get; set; }

        /// <summary>
        /// Digits to right of decimal point in a number
        /// </summary>
        [Property(Field ="DATA_SCALE")]
        public int DataScale { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        [Property(Field = "DATA_DEFAULT")]
        public string DataDefault { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        [Property(Field = "COMMENTS")]
        public string Comments { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        [Property(Field = "NULLABLE")]
        public bool AllowNull { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        [Property(Field = "IS_PRIAMRY_KEY")]
        public bool IsPrimaryKey { get; set; }
    }
}
