using Microsoft.AspNetCore.Mvc;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/RoleView.cshtml");
        }
    }
}
