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

        public AppTaskController(IAppTaskService _appTaskService)
        {
            appTaskService= _appTaskService;
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
            var model = new AddAppTaskViewModel()
            {
                Status= status
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
                await appTaskService.Create(model, User.Id());

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
