using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var machines = await machineService.GetAllMachineAsync();

            var model = machines.Select(m => new AddMachineViewModel()
            {
                Name = m.Name,
                Description = m.Description,
                Code = m.Code,
                Id = m.Id,
                Location = m.Location,
                ImageUrl = m.ImageUrl
            });
            return View(model);
        }

        public async Task<IActionResult> Details(int machineId)
        {
            var model = new MachineDetailsViewModel();

            if ((await machineService.Exists(machineId)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var machine = await machineService.GetMachineByIdAsync(machineId);

            model.Name = machine.Name;
            model.Location = machine.Location;
            model.Description = machine.Description;
            model.Code = machine.Code;
            model.Id = machine.Id;
            model.ImageUrl = machine.ImageUrl;

            return View(model);
        }
    }
}
