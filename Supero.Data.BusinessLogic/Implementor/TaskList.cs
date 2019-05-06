using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supero.Data.BusinessLogic.Interface;
using Supero.DataBase.Persister.Interface;
using Persistence = Supero.DataBase.Persister.Model;
using Supero.Model;
using AutoMapper;
using System.Collections.Generic;


namespace Supero.Data.BusinessLogic.Implementor
{
    public class TaskList : ITaskList
    {
        private readonly ITaskListRepository taskListRepository;

        public TaskList(ITaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;

            Mapper.CreateMap<Supero.Model.TaskListItems, Persistence.TaskList>();
        }

    public Persistence.TaskListResponse GetTaskList()
    {
      taskListRepository.SetContextAsMaster();

      var items = taskListRepository.GetAll().ToList();

    
      var response = new Persistence.TaskListResponse() { Tasklist = items };

        return response;
     }

    public void AddTaskList(TaskListItems items)
        {
            taskListRepository.SetContextAsMaster();

            var mappedObject = Mapper.Map<Persistence.TaskList>(items);

            taskListRepository.Add(mappedObject);
            taskListRepository.Save();

        }

        public void UpdateTaskList(TaskListItems items)
        {
            taskListRepository.SetContextAsMaster();

            var taskList = taskListRepository.FindById(items.Id);

            taskList.Title = items.Title;
            taskList.Status = items.Status;
            taskList.LastEdit = items.LastEdit;
            taskList.Conclusion = items.Conclusion;

            taskListRepository.Update(taskList);
            taskListRepository.Save();

            taskListRepository.GetAll();

        }

        public void DeleteTaskList(long taskId)
        {
            taskListRepository.SetContextAsMaster();

            var taskList = taskListRepository.FindById(taskId);

            taskListRepository.Delete(taskList);
            taskListRepository.Save();

        }
    }
}
