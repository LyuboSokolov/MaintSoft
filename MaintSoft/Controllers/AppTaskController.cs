using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using MaintSoft.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize]
    public class AppTaskController : Controller
    {
        private readonly IAppTaskService appTaskService;
        private readonly IMachineService machineService;
        private readonly IUserService userService;
        private readonly ISparePartService sparePartService;

        public AppTaskController(IAppTaskService _appTaskService,
            IMachineService _machineService,
            IUserService _userService,
            ISparePartService _sparePartService)
        {
            appTaskService = _appTaskService;
            machineService = _machineService;
            userService = _userService;
            sparePartService = _sparePartService;
        }


        public async Task<IActionResult> All()
        {
            var model = await appTaskService.GetAllAppTaskAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var status = await appTaskService.GetAllStatusAsync();
            var machines = await machineService.GetAllMachineAsync();
            var model = new AddAppTaskViewModel()
            {
                Status = status,
                Machines = machines
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAppTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await appTaskService.CreateAsync(model, User.Id());

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> Details(string taskId, string machineName)
        {
            if (taskId == null || machineName == null)
            {
                ModelState.AddModelError("", "Invalid Task!");
                return RedirectToAction("All", "AppTask");
            }
            var appTask = await appTaskService.GetAppTaskByIdAsync(int.Parse(taskId));
            var userCreatedTask = await userService.GetApplicationUserByIdAsync(appTask.UserCreatedId);
            var status = await appTaskService.GetStatusByIdAsync(appTask.StatusId);
            var spareParts = await sparePartService.GetAllSparePartAsync();

            var model = new AppTaskDetailsViewModel()
            {
                Name = appTask.Name,
                CreatedDate = appTask.CreatedDate,
                Description = appTask.Description,
                MachineName = machineName,
                Status = status.Name,
                UserCreatedFullName = $"{userCreatedTask.FirstName} {userCreatedTask.LastName}",
                Id = appTask.Id,
                SpareParts = spareParts
            };
                

            return View(model);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("All");
        }
    }
}
