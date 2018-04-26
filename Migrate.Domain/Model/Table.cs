using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Migrate.Domain.Helper.Adapter;

namespace Migrate.Domain.Model
{
    [Serializable]
    public class Table
    {
        [Property(Field = "OBJECT_ID")]
        public string Id { get; set; }

        [Property(Field = "OBJECT_NAME")]
        public string Name { get; set; }

        [Property(Field = "TABLESPACE_NAME")]
        public string TablespaceName { get; set; }

        [Property(Field = "CREATED")]
        public DateTime CreateDate { get; set; }

        [Property(Field = "COMMENTS")]
        public string Comments { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public IEnumerable<Column> Columns { get; set; }
    }
}
