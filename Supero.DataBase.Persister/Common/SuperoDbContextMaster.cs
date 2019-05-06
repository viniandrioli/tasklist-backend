using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.DataBase.Persister.Common
{
    class SuperoDbContextMaster : SuperoDbContext
    {
        public SuperoDbContextMaster()
            : base(nameOrConnectionString: "SuperoDbContext")
        {
        }
    }
}
