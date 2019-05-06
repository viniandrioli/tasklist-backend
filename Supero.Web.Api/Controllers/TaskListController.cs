using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Supero.Model;
using Supero.Data.BusinessLogic.Interface;
using Supero.Web.Api.Common;
using Persistence = Supero.DataBase.Persister.Model;


namespace Supero.Controllers
{
    [RoutePrefix("api/tasklist")]
    public class TaskListController : BaseApiController
    {

        protected internal ITaskList TaskListService
        {
            get
            {
                return ApiContainer.GetInstance<ITaskList>();
            }
        }

        [Route("gettask")]
        [HttpGet]
        public Persistence.TaskListResponse get()
        {
            var response = TaskListService.GetTaskList();

            return response;
        }


        [Route("addtask")]
        [HttpPost]
        public IHttpActionResult add(TaskListItems items)
        {
            TaskListService.AddTaskList(items);

            return Ok();

        }

        [Route("updatetask")]
        [HttpPost]
        public IHttpActionResult update(TaskListItems items)
        {
            TaskListService.UpdateTaskList(items);

            return Ok();

        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult delete(long id)
        {
            TaskListService.DeleteTaskList(id);

            return Ok();

        }
    }
}
