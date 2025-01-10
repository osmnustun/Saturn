using Microsoft.AspNetCore.Mvc;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/RoleView.cshtml");
        }
    }
}
