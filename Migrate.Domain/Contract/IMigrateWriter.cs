using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Contract
{
    /// <summary>
    /// 迁移写入器
    /// </summary>
    public interface IMigrateWriter : IMigrateIO
    {
        void Write(IMigrateObject mo);
    }
}
