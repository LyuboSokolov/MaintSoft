using MaintSoft.Core.Contracts;
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

        public async Task<List<Machine>> GetAllMachineAsync()
        {
            return await repo.AllReadonly<Machine>().ToListAsync();
        }

        public async Task<Machine> GetMachineByIdAsync(int machineId)
        {
            return await repo.GetByIdAsync<Machine>(machineId);
        }
    }
}
