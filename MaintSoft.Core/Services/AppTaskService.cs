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

        private readonly ISparePartService sparePartService;

        public AppTaskService(
            IRepository _repo,
            ISparePartService _sparePartService)
        {
            repo = _repo;
            sparePartService = _sparePartService;
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
            if (model.StatusId == 4)
            {
                appTask.UserContractorId = userId;
                appTask.UpdatedDate = DateTime.Now;
            }

            await repo.AddAsync<AppTask>(appTask);
            appTask.ApplicationUsersAppTasks.Add(new ApplicationUserAppTask() { ApplicationUserId = userId });
            appTask.MachinesAppTasks.Add(new MachineAppTask() { MachineId = model.MachineId });
            await repo.SaveChangesAsync();

            return appTask.Id;
        }

        public async Task<AppTasksQueryModel> GetAllAppTaskAsync(string? status = null, string? searchTerm = null,
            AppTaskSorting sorting = AppTaskSorting.Newest, int currentPage = 1, int appTaskPerPage = 1)
        {
            var result = new AppTasksQueryModel();
            var appTask = repo.AllReadonly<AppTask>()
                .Include(x => x.Status)
                .Include(x => x.MachinesAppTasks)
                .ThenInclude(x => x.Machine)
                .Include(t => t.ApplicationUsersAppTasks)
                .ThenInclude(x => x.ApplicationUser)
                .Where(x => x.IsDelete == false);

            if (string.IsNullOrEmpty(status) == false)
            {
                appTask = appTask.Where(x => x.Status.Name == status);
            }
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                appTask = appTask
                        .Where(h => EF.Functions.Like(h.Name.ToLower(), searchTerm) ||
                                    EF.Functions.Like(h.Description.ToLower(), searchTerm) ||
                                    EF.Functions.Like(h.Status.Name.ToLower(), searchTerm) ||
                                    h.MachinesAppTasks.Any(m => EF.Functions.Like(m.Machine.Name.ToLower(), searchTerm)) ||
                                    h.ApplicationUsersAppTasks.Any(u => EF.Functions.Like(u.ApplicationUser.FirstName.ToLower(), searchTerm)) ||
                                    h.ApplicationUsersAppTasks.Any(u => EF.Functions.Like(u.ApplicationUser.LastName.ToLower(), searchTerm)));

            }

            appTask = sorting switch
            {
                AppTaskSorting.Oldest => appTask
                    .OrderBy(x => x.CreatedDate),
                _ => appTask.OrderByDescending(h => h.CreatedDate)
            };

            result.AppTasks = await appTask
                .Skip((currentPage - 1) * appTaskPerPage)
                .Take(appTaskPerPage)
                .Select(t => new AppTaskViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    StatusName = t.Status.Name,
                    UserCreatedFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId)).ApplicationUser.FirstName + " " +
            (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserCreatedId)).ApplicationUser.LastName,
                    UserContractorFullName = (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserContractorId)).ApplicationUser.FirstName + " " +
            (t.ApplicationUsersAppTasks.FirstOrDefault(x => x.ApplicationUserId == t.UserContractorId)).ApplicationUser.LastName,
                    CreatedDate = t.CreatedDate,
                    UpdatedDate = t.UpdatedDate,
                    MachineName = (t.MachinesAppTasks.FirstOrDefault(x => x.MachineId == x.Machine.Id)).Machine.Name
                })
                .ToListAsync();

            result.TotalAppTasksCount = await appTask.CountAsync();

            return result;

        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<AppTask>()
                .AnyAsync(t => t.Id == id);
        }

        public async Task<AppTask> GetAppTaskByIdAsync(int appTaskId)
        {
            return await repo.AllReadonly<AppTask>()
                .Include(x => x.MachinesAppTasks)
                .ThenInclude(x => x.Machine)
                .FirstOrDefaultAsync(x => x.Id == appTaskId);
        }

        public async Task StartStopTaskAsync(int appTaskId)
        {
            var appTask = await repo.GetByIdAsync<AppTask>(appTaskId);
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
            var appTask = await repo.GetByIdAsync<AppTask>(appTaskId);
            var status = await GetAllStatusAsync();

            appTask.UserContractorId = userId;

            var applicationUserAppTask = await repo.AllReadonly<ApplicationUserAppTask>()
                .Where(x => x.AppTaskId == appTaskId && x.ApplicationUserId == userId)
                .ToListAsync();

            if (applicationUserAppTask?.Count == 0)
            {
                appTask.ApplicationUsersAppTasks = new List<ApplicationUserAppTask>();
                appTask.ApplicationUsersAppTasks.Add(new ApplicationUserAppTask { ApplicationUserId = userId });
            }

            appTask.StatusId = (status.FirstOrDefault(x => x.Name == "Done")).Id;
            appTask.UpdatedDate = DateTime.Now;
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int appTaskId, string userId)
        {
            var appTask = await repo.GetByIdAsync<AppTask>(appTaskId);

            if (appTask == null)
            {
                return;
            }

            appTask.IsDelete = true;
            appTask.UserDeleteId = userId;
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<string>> AllStatusNames()
        {
            return await repo.AllReadonly<Status>()
                 .Select(x => x.Name)
                 .Distinct()
                 .ToListAsync();
        }


        //public async Task AddSparePart(int appTaskId, string machineName, int sparePartId)
        //{
        //    var appTask = await GetAppTaskByIdAsync(appTaskId);
        //    var sparePart = await sparePartService.GetSparePartByIdAsync(sparePartId);

        //    var machine = await repo.AllReadonly<MaintSoft.Infrastructure.Data.Machine>()
        //        .FirstOrDefaultAsync(x => x.Name == machineName);

        //    machine.SpareParts.Add(sparePart);
        //    sparePart.Machines.Add(machine);
        //    //(appTask.MachinesAppTasks.FirstOrDefault(x => x.Machine.Name == machineName)).Machine;

        //    sparePart.Quantity -= 1;


        //    await repo.SaveChangesAsync();
        //}
    }
}
