using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{
    public class AppTaskService : IAppTaskService
    {
        private readonly IRepository repo;
        private readonly IMachineService machineService;

        public AppTaskService(IRepository _repo,
            IMachineService _machineService)
        {
            repo = _repo;
            machineService = _machineService;
        }

        public async Task<IEnumerable<Status>> GetAllStatusAsync()
        {
            return await repo.AllReadonly<Status>().ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int statusId)
        {
            return await repo.GetByIdAsync<Status>(statusId);
        }

        public async Task<int> CreateAsync(AddAppTaskViewModel model, string userId)
        {
            //var status = await GetStatusByIdAsync(model.StatusId);
            //var machine = await machineService.GetMachineByIdAsync(model.MachineId);
            var appTask = new AppTask()
            {
              Name= model.Name,
              Description =model.Description,
              StatusId=model.StatusId,
              CreatedDate= DateTime.Now,
              UpdatedDate = model?.UpdatedDate,
              UserCreatedId= userId,
              ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
              MachinesAppTasks = new List<MachineAppTask>()
        };

            await repo.AddAsync<AppTask>(appTask);
            appTask.ApplicationUsersAppTasks.Add(new ApplicationUserAppTask() { ApplicationUserId = userId});
            appTask.MachinesAppTasks.Add(new MachineAppTask() { MachineId = model.MachineId });
            await repo.SaveChangesAsync();
     
            return appTask.Id;
        }

        public async Task<IEnumerable<AppTaskViewModel>> GetAllAppTaskAsync()
        {
            var tasks = await repo.AllReadonly<AppTask>()
                .Include(x=> x.Status)
                .Include(x=>x.MachinesAppTasks)
                .ThenInclude(x=>x.Machine)
                .Include(t=>t.ApplicationUsersAppTasks)
                .ThenInclude(x=> x.ApplicationUser)
                .ToListAsync();

            return tasks.Select(t => new AppTaskViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t?.Status.Name,
                UserCreatedFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x=> x.ApplicationUserId ==t.UserCreatedId))?.ApplicationUser?.FirstName + " "+
                (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId))?.ApplicationUser?.LastName,
                UserContractorFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.FirstName + " " +
                (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.LastName,
                CreatedDate = t.CreatedDate,
                UpdatedDate = t.UpdatedDate,
                MachineName = (t.MachinesAppTasks.FirstOrDefault(x=> x.MachineId == x.Machine.Id)).Machine.Name
                                
            });
        }

        public async Task<AppTask> GetAppTaskByIdAsync(int appTaskId)
        {
           return await repo.GetByIdAsync<AppTask>(appTaskId);
        }
    }
}
