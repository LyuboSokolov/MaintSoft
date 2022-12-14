using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Asset;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Controllers
{
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
                .Select( a => new AssetViewModel()
                {
                    Description = a.Description,
                    Name = a.Name,
                    UserCreatedId = a.UserCreatedId,
                    UserDeletedId = a.UserDeletedId,
                    IsDelete = a.IsDelete,
                    PersonResponsible = $"{a.ApplicationUser.FirstName} {a.ApplicationUser.LastName}"
                });



            return View(models);
        }
    }
}
