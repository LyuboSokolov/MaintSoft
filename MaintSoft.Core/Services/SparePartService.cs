using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.SparePart;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class SparePartService : ISparePartService
    {
        private readonly IRepository repo;
        private readonly IManufacturerService manufacturerService;

        public SparePartService(IRepository _repo,
           IManufacturerService _manufacturerService)
        {
            repo = _repo;
            manufacturerService = _manufacturerService;
        }
        public async Task<int> Create(SparePartViewModel model, string userId)
        {
            var manufacturer = await repo.GetByIdAsync<Manufacturer>(model.ManufacturerId);
            var sparePart = new SparePart()
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Location = model.Location,
                ManufacturerId = model.ManufacturerId,
                Manufacturer = manufacturer,
                Quantity = model.Quantity,
                UserCreatedId = userId
            };

            await repo.AddAsync<SparePart>(sparePart);
            await repo.SaveChangesAsync();
            return sparePart.Id;

        }

        public async Task DeleteAsync(int sparePartId, string userId)
        {
            var sparePart = await GetSparePartByIdAsync(sparePartId);

            if (sparePart == null)
            {
                return;
            }

            sparePart.IsDelete = true;
            sparePart.UserDeletedId = userId;
            await repo.SaveChangesAsync();
        }

        public async Task Edit(int sparePartId,SparePartViewModel model)
        {
            var sparePart = await repo.GetByIdAsync<SparePart>(sparePartId);

            sparePart.ManufacturerId = model.ManufacturerId;
            sparePart.Quantity = model.Quantity;
            sparePart.Code = model.Code;
            sparePart.Description = model.Description;
            sparePart.ImageUrl = model.ImageUrl;
            sparePart.Location = model.Location;
            sparePart.Name = model.Name;

            await repo.SaveChangesAsync();

        }

        public async Task<bool> Exists(int sparePartId)
        {
            return await repo.AllReadonly<SparePart>()
                          .AnyAsync(x => x.Id == sparePartId);
        }

        public async Task<List<SparePart>> GetAllSparePartAsync()
        {
            return await repo.AllReadonly<SparePart>()
                .Where(x => x.IsDelete == false).ToListAsync();
        }

        public async Task<SparePart> GetSparePartByIdAsync(int sparePartId)
        {
            return await repo.GetByIdAsync<SparePart>(sparePartId);
        }


    }
}
