using MaintSoft.Core.Contracts;
using MaintSoft.Core.Models.AppTask;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MaintSoft.Core.Services
{
    public class AppTaskService : IAppTaskService
    {
        private readonly IRepository repo;
        private readonly IMachineService machineService;
        private readonly IUserService userService;

        public AppTaskService(IRepository _repo,
            IMachineService _machineService,
            IUserService _userService)
        {
            repo = _repo;
            machineService = _machineService;
            userService = _userService;
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
                Name = model.Name,
                Description = model.Description,
                StatusId = model.StatusId,
                CreatedDate = DateTime.Now,
                UpdatedDate = model?.UpdatedDate,
                UserCreatedId = userId,
                ApplicationUsersAppTasks = new List<ApplicationUserAppTask>(),
                MachinesAppTasks = new List<MachineAppTask>()
            };

            await repo.AddAsync<AppTask>(appTask);
            appTask.ApplicationUsersAppTasks.Add(new ApplicationUserAppTask() { ApplicationUserId = userId });
            appTask.MachinesAppTasks.Add(new MachineAppTask() { MachineId = model.MachineId });
            await repo.SaveChangesAsync();

            return appTask.Id;
        }

        public async Task<IEnumerable<AppTaskViewModel>> GetAllAppTaskAsync()
        {
            var tasks = await repo.AllReadonly<AppTask>()
                .Include(x => x.Status)
                .Include(x => x.MachinesAppTasks)
                .ThenInclude(x => x.Machine)
                .Include(t => t.ApplicationUsersAppTasks)
                .ThenInclude(x => x.ApplicationUser)
                .ToListAsync();

            //var allApplicationUsers = await userService.GetAllApplicationUsersAsync();

            //tasks.Select( x=> new AppTaskViewModel()
            //{

            //})


            return tasks.Select(t => new AppTaskViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t?.Status.Name,
                UserCreatedFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId))?.ApplicationUser?.FirstName + " " +
                (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId))?.ApplicationUser?.LastName,
                UserContractorFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.FirstName + " " +
                (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t?.UserContractorId))?.ApplicationUser?.LastName,
                CreatedDate = t.CreatedDate,
                UpdatedDate = t.UpdatedDate,
                MachineName = (t.MachinesAppTasks.FirstOrDefault(x => x.MachineId == x.Machine.Id)).Machine.Name

            });
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<AppTask>()
                .AnyAsync(t => t.Id == id);
        }

        public async Task<AppTask> GetAppTaskByIdAsync(int appTaskId)
        {
            return await repo.GetByIdAsync<AppTask>(appTaskId);
        }

        public async Task StartStopTaskAsync(int appTaskId)
        {
            var appTask = await GetAppTaskByIdAsync(appTaskId);
            var status = await GetAllStatusAsync();
            var appTaskStatus = (status.FirstOrDefault(x => x.Id == appTask.StatusId)).Name;

            if (appTaskStatus == "In Process")
            {
                appTask.StatusId = status.FirstOrDefault(x => x.Name == "Stopped").Id;
            }
            else if (appTaskStatus == "Stopped" || appTaskStatus == "New")
            {
                appTask.StatusId = status.FirstOrDefault(x => x.Name == "In Process").Id;
            }

            appTask.UpdatedDate = DateTime.Now;
            await repo.SaveChangesAsync();
        }

        public async Task CompleteTaskAsync(int appTaskId, string userId)
        {
            var appTask = await GetAppTaskByIdAsync(appTaskId);
            var status = await GetAllStatusAsync();

            appTask.UserContractorId = userId;

            var applicationUserAppTask = await repo.AllReadonly<ApplicationUserAppTask>()
                .Where(x => x.AppTaskId == appTaskId && x.ApplicationUserId == userId)
                .ToListAsync();

            if (applicationUserAppTask?.Count ==0)
            {
                appTask.ApplicationUsersAppTasks = new List<ApplicationUserAppTask>();
                appTask.ApplicationUsersAppTasks.Add(new ApplicationUserAppTask { ApplicationUserId = userId });
            }

          


            appTask.StatusId = (status.FirstOrDefault(x => x.Name == "Completed")).Id;
            appTask.UpdatedDate = DateTime.Now;
            await repo.SaveChangesAsync();
        }
    }
}
