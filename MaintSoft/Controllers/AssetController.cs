using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Asset;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AssetController : Controller
    {
        private readonly IAssetService assetService;
        private readonly IUserService userService;

        public AssetController(
            IAssetService _assetService,
            IUserService _userService)
        {
            assetService = _assetService;
            userService = _userService;
        }

        public async Task<IActionResult> All()
        {
            var assets = await assetService.GetAllAssetsAsync();

            var models = assets
                .Select(a => new AssetViewModel()
                {
                    Description = a.Description,
                    Name = a.Name,
                    UserCreatedId = a.UserCreatedId,
                    UserDeletedId = a.UserDeletedId,
                    IsDelete = a.IsDelete,
                    PersonResponsible = $"{a.ApplicationUser.FirstName} {a.ApplicationUser.LastName}",
                    IsAvailable = a.IsAvailable
                });

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var model = new AddAssetViewModel()
            {
                ApplicationUsers = await userService.GetAllApplicationUsersAsync(),
                UserCreatedId = User.Id()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAssetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await assetService.CreateAsync(model, User.Id());

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}

