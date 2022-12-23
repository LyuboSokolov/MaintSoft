using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Asset;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository repo;
        private readonly IUserService userService;

        public AssetService(
            IRepository _repo,
            IUserService _userService)
        {
            repo = _repo;
            userService = _userService;
        }

        public async Task CreateAsync(AddAssetViewModel model, string userId)
        {
            var applicationUser = await repo.GetByIdAsync<ApplicationUser>(model.ApplicationUserId);

            var asset = new Asset()
            {
                Name = model.Name,
                UserCreatedId = userId,
                Description = model.Description,
                IsAvailable = model.IsAvailable,
                ApplicationUserId = model.ApplicationUserId,
                ApplicationUser = applicationUser,
            };

            await repo.AddAsync<Asset>(asset);
            await repo.SaveChangesAsync();
        }

        public async Task<List<Asset>> GetAllAssetsAsync()
        {
            return await repo.AllReadonly<Asset>()
                .Where(a => a.IsDelete == false)
                .Include(a => a.ApplicationUser)
                .ToListAsync();
        }
    }
}
