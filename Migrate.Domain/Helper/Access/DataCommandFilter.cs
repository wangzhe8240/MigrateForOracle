using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Migrate.Domain.Helper.Access
{
    public class DataCommandFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public String CommandText { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public IDbDataParameter[] Params { set; get; }
    }
}
