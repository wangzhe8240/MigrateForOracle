using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Domain.Contract
{
    public interface IMigrateIO : IDisposable
    {
        IMigrateIO Open();
    }
}
