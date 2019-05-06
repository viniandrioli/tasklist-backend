using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supero.DataBase.Persister.Common;
using Supero.DataBase.Persister.Model;
using Supero.DataBase.Persister.Interface;

namespace Supero.DataBase.Persister.Implementor
{
    public class TaskListRepository : Repository<SuperoDbContext, TaskList>, ITaskListRepository
    {
        public TaskListRepository()
        {

        }

        public TaskList FindById(long taskId)
        {
            return GetAll().FirstOrDefault(x => x.Id == taskId);
        }

    }
}
