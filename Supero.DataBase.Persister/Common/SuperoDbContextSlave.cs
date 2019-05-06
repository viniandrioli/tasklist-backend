using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.DataBase.Persister.Common
{
    class SuperoDbContextSlave : SuperoDbContext
    {
        public SuperoDbContextSlave()
            : base(nameOrConnectionString: "SuperoDbContext-Slave")
        {
        }
    }
}
