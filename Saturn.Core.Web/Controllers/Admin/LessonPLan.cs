using Microsoft.AspNetCore.Mvc;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class LessonPLan : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/LessonPLanView.cshtml");
        }
    }
}
