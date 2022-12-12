using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Manufacturer;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Mvc;
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
                Contacts = model.Contacts,
                Description = model.Description,
                VAT = model.VAT,
                UserCreatedId = userId
            };

            await repo.AddAsync<Manufacturer>(manufacturer);
            await repo.SaveChangesAsync();
            return manufacturer.Id;
        }

        [HttpPost]
        public async Task DeleteAsync(int manufacturerId, string userId)
        {
            var manufacturer = await GetManufacturerByIdAsync(manufacturerId);
            manufacturer.IsDelete = true;
            manufacturer.UserDeletedId= userId;
            await repo.SaveChangesAsync();
        }

        public async Task Edit(int manufacturerId, ManufacturerViewModel model)
        {
            var manufacturer = await GetManufacturerByIdAsync(manufacturerId);

            manufacturer.Name = model.Name;
            manufacturer.Address = model.Address;
            manufacturer.Contacts = model.Contacts;
            manufacturer.Description = model.Description;
            manufacturer.VAT = model.VAT;

            await repo.SaveChangesAsync();

        }

        public async Task<bool> Exists(int manufacturerId)
        {
            return await repo.AllReadonly<Manufacturer>()
               .AnyAsync(m => m.Id == manufacturerId);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync()
        {
            return await repo.AllReadonly<Manufacturer>()
                .Where(x => x.IsDelete == false)
                .ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerByIdAsync(int manufacturerId)
        {
            return await repo.GetByIdAsync<Manufacturer>(manufacturerId);
        }
    }
}
