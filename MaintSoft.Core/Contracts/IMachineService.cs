using MaintSoft.Core.Models.Machine;
using MaintSoft.Infrastructure.Data;

namespace MaintSoft.Core.Contracts
{
    public interface IMachineService
    {
        Task<Machine> GetMachineByIdAsync(int machineId);

        Task<List<Machine>> GetAllMachineAsync();

        Task<int> CreateAsync(AddMachineViewModel model, string userId);
    }
}
