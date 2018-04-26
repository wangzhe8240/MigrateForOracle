using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Contract
{
    /// <summary>
    /// 迁移读取器
    /// </summary>
    public interface IMigrateReader:IMigrateIO
    {
        IMigrateObject Read();
    }
}
