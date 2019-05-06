using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supero.Model;
using Persistence = Supero.DataBase.Persister.Model;

namespace Supero.Data.BusinessLogic.Interface
{
    public interface ITaskList
    {

        Persistence.TaskListResponse GetTaskList();

        void AddTaskList(TaskListItems items);

        void UpdateTaskList(TaskListItems items);

        void DeleteTaskList(long taskId);
    }
}
