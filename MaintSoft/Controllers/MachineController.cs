using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize(Roles ="Administrator,Engineer")]
    public class MachineController : Controller
    {
        private readonly IMachineService machineService;
        private readonly IUserService userService;

        public MachineController(
            IMachineService _machineService,
            IUserService _userService)
        {
            machineService = _machineService;
            userService = _userService;
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

        public async Task<IActionResult> Delete(int machineId)
        {
            if (await machineService.Exists(machineId) == false)
            {
                return RedirectToAction(nameof(All));
            }

            await machineService.DeleteAsync(machineId, User.Id());

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int machineId)
        {
            var machine = await machineService.GetMachineByIdAsync(machineId);

            if (machine == null)
            {
                return RedirectToAction(nameof(All));
            }

            var model = new AddMachineViewModel()
            {
                Id = machine.Id,
                Name = machine.Name,
                Code = machine.Code,
                ImageUrl = machine.ImageUrl,
                Description = machine.Description,
                Location = machine.Location
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int machineId, AddMachineViewModel model)
        {
            if (machineId != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await machineService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Machine does not exist!");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await machineService.Edit(machineId, model);

            return RedirectToAction(nameof(All));
        }
    }
}
