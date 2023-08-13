using MaintSoft.Areas.Admin.Models;
using MaintSoft.Core.Contracts;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using MaintSoft.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService _userService,
           UserManager<ApplicationUser> _userManager )
        {
            userService = _userService;
            userManager = _userManager;
        }

        public async Task<IActionResult> All()
        {
            var allUsers = await userService.GetAllApplicationUsersAsync();
     
            var result = new List<UserServiceModel>();

            foreach(var user in allUsers )
            {

                result.Add( new UserServiceModel()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}",
                    JobPosition = user.JobPosition,
                    Role = await userManager.GetRolesAsync(user)

                });
            }

          result = result.Where(x => x.UserId != User.Id()).ToList();

            //var model = allUsers.Where(x => x.Id != User.Id())
            //    .Select(x => new UserServiceModel()
            //    {
            //        UserId = x.Id,
            //        Email = x.Email,
            //        FullName = $"{x.FirstName} {x.LastName}",
            //        JobPosition = x.JobPosition,
            //        //  Role =  userManager.GetRolesAsync(x)

            //    });
               
            return View(result);
        }

        public async Task<IActionResult> Delete(string userId)
        {

            if (await userService.Exists(userId) == false)
            {
                return RedirectToAction(nameof(All));
            }
            await userService.DeleteById(userId);

            return RedirectToAction(nameof(All));
        }
    }
}
