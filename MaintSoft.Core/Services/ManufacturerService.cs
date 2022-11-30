using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
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
        private readonly IRepository repo;

        public ManufacturerService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturer()
        {
            return await repo.AllReadonly<Manufacturer>().ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerById(int manufacturerId)
        {
            return await repo.GetByIdAsync<Manufacturer>(manufacturerId);
        }
    }
}
