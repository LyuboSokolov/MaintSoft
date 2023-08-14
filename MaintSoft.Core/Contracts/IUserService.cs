using MaintSoft.Infrastructure.Data;

namespace MaintSoft.Core.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetApplicationUserByIdAsync(string userId);

        Task<List<ApplicationUser>> GetAllApplicationUsersAsync();

        Task<string> GetUserFullName(string userId);

        Task DeleteById(string userId);

        Task<bool> Exists(string userId);

        Task<ApplicationUser> GetApplicationUserByEmail(string email);

        Task<ApplicationUser> EditUser(string userId, string firstName, string lastName, string jobPosition);
    }
}
