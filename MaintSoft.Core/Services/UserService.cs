using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
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
            return await repo.AllReadonly<ApplicationUser>()
                .Where(x => x.IsDelete == false)
                .ToListAsync();
        }

        public async Task<string> GetUserFullName(string userId)
        {

            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            return $"{user.FirstName} ${user.LastName}";
        }

        public async Task DeleteById(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);

            user.IsDelete = true;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(string userId)
        {

            return await repo.AllReadonly<ApplicationUser>()
                          .AnyAsync(x => x.Id == userId);
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string email)
        {
            return await repo.AllReadonly<ApplicationUser>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ApplicationUser> EditUser(string userId, string firstName, string lastName, string jobPosition)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.JobPosition = jobPosition;
            await repo.SaveChangesAsync();

            return user;
        }

    }
}
