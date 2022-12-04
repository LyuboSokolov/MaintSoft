using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize]
    public class MachineController : Controller
    {
        private readonly IMachineService machineService;

        public MachineController(IMachineService _machineService)
        {
            machineService = _machineService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddMachineViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMachineViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            try
            {
                await machineService.CreateAsync(model, User.Id());

                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
