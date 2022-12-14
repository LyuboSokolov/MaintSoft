using MaintSoft.Areas.Admin.Models;
using MaintSoft.Core.Contracts;
using MaintSoft.Core.Services;
using MaintSoft.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> All()
        {
            var allUsers = await userService.GetAllApplicationUsersAsync();

            var model = allUsers.Where(x=> x.Id != User.Id()).Select(x => new UserServiceModel()
            {
                UserId = x.Id,
                Email = x.Email,
                FullName = $"{x.FirstName} {x.LastName}",
                JobPosition = x.JobPosition
            });
            return View(model);
        }

        public async Task<IActionResult> Delete(string userId)
        {
            
            if (await userService.Exists(userId)==false)
            {
                return RedirectToAction(nameof(All));
            }
            await userService.DeleteById(userId);

            return RedirectToAction(nameof(All));
        }
    }
}
