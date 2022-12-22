using Microsoft.AspNetCore.Mvc;

namespace MaintSoft.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult A()
        {
            return View();
        }
    }
}
