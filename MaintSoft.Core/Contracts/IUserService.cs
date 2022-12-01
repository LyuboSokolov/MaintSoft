using MaintSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetApplicationUserByIdAsync(string userId);
    }
}
