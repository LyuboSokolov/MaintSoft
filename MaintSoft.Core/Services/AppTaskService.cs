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

        public AppTaskService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<Status>> GetAllStatusAsync()
        {
            return await repo.AllReadonly<Status>().ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int statusId)
        {
            return await repo.GetByIdAsync<Status>(statusId);
        }

        public async Task<int> Create(AddAppTaskViewModel model, string userId)
        {
            var status = await GetStatusByIdAsync(model.StatusId);
            var appTask = new AppTask()
            {
              Name= model.Name,
              Description =model.Description,
              StatusId= status.Id,
              CreatedDate= DateTime.Now,
              UpdatedDate = model?.UpdatedDate,
              UserCreatedId= userId
            };

            await repo.AddAsync<AppTask>(appTask);
            await repo.SaveChangesAsync();
            var applicationUserAppTask = new ApplicationUserAppTask()
            {
                ApplicationUserId = userId,
                AppTaskId = appTask.Id
            };
            await repo.AddAsync<ApplicationUserAppTask>(applicationUserAppTask);
            await repo.SaveChangesAsync();
            return appTask.Id;
        }

        public async Task<IEnumerable<AppTaskViewModel>> GetAllAppTaskAsync()
        {
            var tasks = await repo.AllReadonly<AppTask>().Include(x=> x.Status).Include(t=>t.ApplicationUsersAppTasks).ThenInclude(x=> x.ApplicationUser).ToListAsync();

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
                UpdatedDate = t.UpdatedDate
            });
        }

     
    }
}
