using Microsoft.AspNetCore.Mvc;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/ReportView.cshtml");
        }
    }
}
