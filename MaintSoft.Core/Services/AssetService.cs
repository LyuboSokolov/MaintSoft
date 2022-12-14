using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository repo;

        public AssetService(IRepository _repo)
        {
            repo = _repo;
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
