using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize]
    public class AppTaskController : Controller
    {
        private readonly IAppTaskService appTaskService;
        private readonly IMachineService machineService;
        public AppTaskController(IAppTaskService _appTaskService,
            IMachineService _machineService)
        {
            appTaskService= _appTaskService;
            machineService= _machineService;
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
                Status= status,
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

        public IActionResult Details()
        {
            return View();
        }
    }
}
