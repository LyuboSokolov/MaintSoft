using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{


    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string userId)
        {
            return await repo.GetByIdAsync<ApplicationUser>(userId);
        }

        public async Task<List<ApplicationUser>> GetAllApplicationUsersAsync()
        {
            return await repo.AllReadonly<ApplicationUser>().ToListAsync();
        }

        public async Task<string> GetUserFullName(string userId)
        {

            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            return $"{user.FirstName} ${user.LastName}";
        }
    }
}
