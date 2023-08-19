using MaintSoft.Areas.Constants;
using MaintSoft.Core.Contracts;
using MaintSoft.Extensions;
using MaintSoft.Infrastructure.Data;
using MaintSoft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static MaintSoft.Areas.Constants.AdminConstants;
namespace MaintSoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Index()
        {
            var userrole = User.IsInRole("Administrator");
            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Admin", new { area = AreaName });
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Chat()
        {
           var user = await userService.GetApplicationUserByIdAsync(User.Id());
            var model = new ApplicationUser()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                JobPosition=user.JobPosition

            };

            return View(model);
        }
    }
}