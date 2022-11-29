using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.SparePart;
using MaintSoft.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Services
{
    public class SparePartService : ISparePartService
    {
        private readonly MaintSoftDbContext context;
        private readonly IManufacturerService manufacturerService;

        public SparePartService(MaintSoftDbContext _context,
           IManufacturerService _manufacturerService )
        {
            context = _context; 
            manufacturerService = _manufacturerService;
        }
        public async Task<int> Create(SparePartViewModel model, string userId)
        {
            var manufacturer = await manufacturerService.GetManufacturerById(model.ManufacturerId);
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
           
            var result =  context.SpareParts.Add(sparePart);
            context.SaveChangesAsync();
            return sparePart.Id;
            
        }
    }
}
