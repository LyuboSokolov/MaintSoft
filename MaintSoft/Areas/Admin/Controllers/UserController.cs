using MaintSoft.Areas.Admin.Models;
using MaintSoft.Core.Contracts;
using MaintSoft.Extensions;
using MaintSoft.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MaintSoft.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(IUserService _userService,
           UserManager<ApplicationUser> _userManager,
           RoleManager<IdentityRole> _roleManager)
        {
            userService = _userService;
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IActionResult> All()
        {
            var allUsers = await userService.GetAllApplicationUsersAsync();

            var result = new List<UserServiceModel>();

            foreach (var user in allUsers)
            {

                result.Add(new UserServiceModel()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = $"{user.FirstName} {user.LastName}",
                    JobPosition = user.JobPosition,
                    Role = await userManager.GetRolesAsync(user)

                });
            }

            result = result.Where(x => x.UserId != User.Id()).ToList();

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

        [HttpGet]
        public async Task<IActionResult> EditRole(string userId)
        {
            if (await userService.Exists(userId) == false)
            {
                return RedirectToAction(nameof(All));
            }
            var user = await userService.GetApplicationUserByIdAsync(userId);

            var model = new UserEditModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                JobPosition = user.JobPosition,
                RoleName = (await userManager.GetRolesAsync(user)).SingleOrDefault(),
                AllRoles = await roleManager.Roles.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(string userId, UserEditModel model)
        {
            if (userId != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await userService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "User does not exist!");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                model.AllRoles = await roleManager.Roles.ToListAsync();
                return View(model);
            }

            var user = await userService.EditUser(userId, model.FirstName, model.LastName, model.JobPosition);

            var role = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            await userManager.RemoveFromRoleAsync(user, role);
            await userManager.AddToRoleAsync(user, model.RoleName);

            return RedirectToAction(nameof(All));
        }

    }
}
