using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using MaintSoft.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var tasks = await appTaskService.GetAllAppTaskAsync();
            tasks = tasks.OrderByDescending(x => x.CreatedDate).ToList();
            var models = tasks.Select(t => new AppTaskViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t?.Status.Name,
                UserCreatedFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId))?.ApplicationUser?.FirstName + " " +
            (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId))?.ApplicationUser?.LastName,
                UserContractorFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.FirstName + " " +
            (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.LastName,
                CreatedDate = t.CreatedDate,
                UpdatedDate = t.UpdatedDate,
                MachineName = (t.MachinesAppTasks.FirstOrDefault(x => x.MachineId == x.Machine.Id)).Machine.Name

            });
            return View(models);
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

        public async Task<IActionResult> Details(int taskId, string machineName)
        {
            if (await appTaskService.Exists(taskId) == false || machineName == null)
            {
                ModelState.AddModelError("", "Invalid Task!");
                return RedirectToAction("All", "AppTask");
            }
            var appTask = await appTaskService.GetAppTaskByIdAsync(taskId);
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
                SpareParts = spareParts,
                UpdatedDate = appTask.UpdatedDate
            };

            TempData["taskId"] = taskId;
            TempData["machineName"] = machineName;
            return View(model);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("All");
        }

        public async Task<IActionResult> StartStopTask(int taskId)
        {
            await appTaskService.StartStopTaskAsync(taskId);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> CompleteTask(int taskId)
        {
            await appTaskService.CompleteTaskAsync(taskId, User.Id());
            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int appTaskId)
        {
            var appTask = await appTaskService.Exists(appTaskId);

            if (appTask == false)
            {
                return RedirectToAction(nameof(All));
            }

            await appTaskService.DeleteAsync(appTaskId, User.Id());

            return RedirectToAction(nameof(All));
        }


        //public async Task<IActionResult> AddUsedSparePart(int partId)
        //{
        //    var appTaskId = (int)TempData["taskId"];
        //    var machine = (string)TempData["machineName"];

        //    if (partId == 0)
        //    {
        //        //TODO Information to user: No have change to save
        //        return RedirectToAction(nameof(Details), new { taskId = appTaskId, machineName = machine });
        //    }
        //    if ((await sparePartService.Exists(partId)) == false)
        //    {
        //        //TODO Information to user: No exist this part yet
        //        return RedirectToAction(nameof(Details), new { taskId = appTaskId, machineName = machine });
        //    }
        //    var sparePart = await sparePartService.GetSparePartByIdAsync(partId);

        //    if (sparePart.Quantity <= 0)
        //    {
        //        //TODO Information to user: Quntity not enough items to add 
        //        return RedirectToAction(nameof(Details), new { taskId = appTaskId, machineName = machine });
        //    }
        //    await appTaskService.AddSparePart(appTaskId, machine, partId);


        //    return RedirectToAction(nameof(Details), new { taskId = appTaskId, machineName = machine });
        //}
    }
}
