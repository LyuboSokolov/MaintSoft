using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Core.Models.SparePart;
using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{
    public interface IManufacturerService
    {
       
        Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync();

        Task<Manufacturer> GetManufacturerByIdAsync(int manufacturerId);

        Task<int> CreateAsync(ManufacturerViewModel model, string userId);

        Task<bool> Exists(int manufacturerId);

        Task Edit(int manufacturerId,ManufacturerViewModel model);

        Task DeleteAsync(int manufacturerId, string userId);
    }
}
