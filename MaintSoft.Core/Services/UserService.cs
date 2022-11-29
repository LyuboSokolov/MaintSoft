using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintSoft.Core.Services
{
   

    public class UserService:IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<string> GetUserId(string userId)
        {
            return (await repo.AllReadonly<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId))?.Id ?? "";
        }
    }
}
