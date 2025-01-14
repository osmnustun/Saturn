
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Logic.Attributes;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class LessonPLan : Controller
    {
        [AuthorizeClient(["admin","user"])]
        public IActionResult Index()
        {
            return View("~/Views/Admin/LessonPLanView.cshtml");
        }
    }
}
