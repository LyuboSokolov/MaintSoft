using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly MaintSoftDbContext context;

        public ManufacturerService(MaintSoftDbContext _context)
        {
            context=_context;
        }
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturer()
        {
            return await context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerById(int manufacturerId)
        {
            return await context.Manufacturers.FirstOrDefaultAsync(x=> x.Id == manufacturerId);
        }
    }
}
