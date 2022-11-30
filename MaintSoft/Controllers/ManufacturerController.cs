using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
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
                await manufacturerService.Create(model, User.Id());

                return RedirectToAction("Add", "SparePart");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
