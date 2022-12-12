using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Core.Models.SparePart;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MaintSoft.Controllers
{
    [Authorize]
    public class SparePartController : Controller
    {
        private readonly ISparePartService sparePartService;
        private readonly IManufacturerService manufacturerService;

        public SparePartController(ISparePartService _sparePartService,
            IUserService _userService,
            IManufacturerService _manufacturerService)
        {
            sparePartService = _sparePartService;
            manufacturerService = _manufacturerService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new SparePartViewModel()
            {
                Manufacturers = await manufacturerService.GetAllManufacturerAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SparePartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await sparePartService.Create(model, User.Id());

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }



        public async Task<IActionResult> All()
        {
            var spareParts = await sparePartService.GetAllSparePartAsync();
            var models = spareParts.Select(x => new SparePartAllViewModel()
            {
                Name = x.Name,
                Code = x.Code,
                Description = x.Description,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Location = x.Location,
                Quantity = x.Quantity,

            });
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int sparePartId)
        {
            if (await sparePartService.Exists(sparePartId) == null)
            {
                return RedirectToAction(nameof(All));
            }

            await sparePartService.DeleteAsync(sparePartId, User.Id());

            return RedirectToAction(nameof(All));
        }

    }
}
