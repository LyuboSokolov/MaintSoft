using MaintSoft.Areas.Constants;
using MaintSoft.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static MaintSoft.Areas.Constants.AdminConstants;
namespace MaintSoft.Controllers
{
    public class HomeController : Controller
    {
      

     

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
    }
}