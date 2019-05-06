using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supero.DataBase.Persister.Common;
using Supero.DataBase.Persister.Model;

namespace Supero.DataBase.Persister.Interface
{
    public interface ITaskListRepository : IRepository<TaskList>
    {
        TaskList FindById(long taskId);

    }
}
