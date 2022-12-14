using MaintSoft.Core.Models.Asset;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAllAssetsAsync();

        Task CreateAsync(AddAssetViewModel model, string userId);
    }
}
