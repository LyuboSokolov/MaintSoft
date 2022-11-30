using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.SparePart;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
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
                Manufacturers = await manufacturerService.GetAllManufacturer()
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

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
