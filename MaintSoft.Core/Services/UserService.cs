﻿using MaintSoft.Core.Contracts;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MaintSoft.Core.Services
{


    public class UserService:IUserService
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
    }
}
