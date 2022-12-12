using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturerController(IManufacturerService _manufacturerService)
        {
            manufacturerService = _manufacturerService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ManufacturerViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ManufacturerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await manufacturerService.CreateAsync(model, User.Id());

                return RedirectToAction("Add", "SparePart");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> All()
        {
            var manufacturers = await manufacturerService.GetAllManufacturerAsync();

            var models = manufacturers.Select(x => new ManufacturerViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                VAT = x.VAT,
                Address = x.Address,
                Contacts = x.Contacts,
                Description = x.Description
            });

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int manufacturerId)
        {
            var manufacturer = await manufacturerService.GetManufacturerByIdAsync(manufacturerId);

            if (manufacturer == null)
            {
                return RedirectToAction(nameof(All));
            }

            var model = new ManufacturerViewModel()
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Address = manufacturer.Address,
                Contacts = manufacturer.Contacts,
                Description = manufacturer.Description,
                VAT = manufacturer.VAT
            };

            return View(model);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int manufacturerId, ManufacturerViewModel model)
        {
            if (manufacturerId != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await manufacturerService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Manufacturer does not exist!");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await manufacturerService.Edit(manufacturerId, model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(int manufacturerId)
        {
            await manufacturerService.DeleteAsync(manufacturerId, User.Id());

            return RedirectToAction(nameof(All));
        }
    }
}
