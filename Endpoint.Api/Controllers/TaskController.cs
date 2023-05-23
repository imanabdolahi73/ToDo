using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Services.Task;
using ToDo.Application.Utilities;

namespace Endpoint.Api.Controllers
{
    public class TaskController : Controller
    {
        public readonly ITaskManagementService _taskManagementService;
        public TaskController(ITaskManagementService taskManagementService)
        {
            _taskManagementService = taskManagementService;
        }


        [HttpPost]
        public IActionResult List(int? UserId)
        {
            return Json(_taskManagementService.List(UserId));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(Add_Task_Dto request)
        {
            return Json(_taskManagementService.Add(request));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Edit_Task_Dto request)
        {
            request.UserId = ClaimUtility.GetEmployeeId(HttpContext.User);
            return Json(_taskManagementService.Edit(request));
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangeStatus(ChangeStatus_Task_Dto request)
        {
            request.UserId = ClaimUtility.GetEmployeeId(HttpContext.User);
            return Json(_taskManagementService.ChangeStatus(request));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Remove(int TaskID)
        {
            return Json(_taskManagementService.Remove(TaskID , ClaimUtility.GetEmployeeId(HttpContext.User)));
        }

    }
}
