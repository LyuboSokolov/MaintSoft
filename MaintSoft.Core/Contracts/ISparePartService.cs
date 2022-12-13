using MaintSoft.Core.Models.SparePart;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{

    public interface ISparePartService
    {
        Task<int> Create(SparePartViewModel model, string userId);

        Task<List<SparePart>> GetAllSparePartAsync();

        Task<bool> Exists(int sparePartId);

        Task<SparePart> GetSparePartByIdAsync(int sparePartId);

        Task DeleteAsync(int sparePartId, string userId);

        Task Edit(int sparePartId,SparePartViewModel model);
    }
}
