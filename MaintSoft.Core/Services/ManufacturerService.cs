using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository repo;

        public ManufacturerService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> CreateAsync(ManufacturerViewModel model, string userId)
        {
           
            var manufacturer = new Manufacturer()
            {
               Name = model.Name,
               Address = model.Address,
               Contacts= model.Contacts,
               Description= model.Description,
               VAT = model.VAT,
               UserCreatedId = userId
            };

            await repo.AddAsync<Manufacturer>(manufacturer);
            await repo.SaveChangesAsync();
            return manufacturer.Id;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync()
        {
            return await repo.AllReadonly<Manufacturer>().ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int manufacturerId)
        {
            return await repo.GetByIdAsync<Manufacturer>(manufacturerId);
        }
    }
}
