using Microsoft.AspNetCore.Mvc;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/UserView.cshtml"); // Tam yol belirtiliyor
        }
    }
}
