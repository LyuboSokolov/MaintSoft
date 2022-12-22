using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MaintSoft.Areas.Constants.AdminConstants;
namespace MaintSoft.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
      
    }
}
