using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.Machine;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class MachineService : IMachineService
    {
        private readonly IRepository repo;

        public MachineService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<int> CreateAsync(AddMachineViewModel model, string userId)
        {
            var machine = new Machine()
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                Location = model.Location,
                UserCreatedId = userId,
                MachineAppTasks = new List<MachineAppTask>(),
                SpareParts = new List<SparePart>(),
                ImageUrl = model.ImageUrl
            };

            await repo.AddAsync<Machine>(machine);
            await repo.SaveChangesAsync();
            return machine.Id;
        }

        public async Task<bool> Exists(int machineId)
        {
            return await repo.AllReadonly<Machine>()
                             .AnyAsync(m => m.Id == machineId && m.IsDelete == false);
        }
        public async Task<List<Machine>> GetAllMachineAsync()
        {
            return await repo.AllReadonly<Machine>()
                .Where(x => x.IsDelete == false)
                .ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int machineId)
        {
            return await repo.GetByIdAsync<Machine>(machineId);
        }
    }
}
