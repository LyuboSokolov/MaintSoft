﻿using MaintSoft.Core.Contracts;
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
            var manufacturer = await manufacturerService.GetManufacturerByIdAsync(model.ManufacturerId);
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

        public async Task<List<SparePart>> GetAllSparePartAsync()
        {
            return await repo.AllReadonly<SparePart>().ToListAsync();
        }
    }
}
