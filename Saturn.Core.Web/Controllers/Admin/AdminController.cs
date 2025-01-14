
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.DTO;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Attributes;

namespace Saturn.Core.Web.Controllers.Admin
{
 
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AdminController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AuthorizeClient]
        public IActionResult Index()        
        {
            return View("Dashboard");
        }

        [HttpPost]
        public async  Task<IActionResult> CheckUser(UserDTO userDTO)
        {
            Console.WriteLine("Methot Çalıştı");
            var token = await _authenticationService.CheckUser(userDTO);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // JavaScript erişimini engeller
                Secure = true,   // HTTPS üzerinde gönderilir
                SameSite = SameSiteMode.Strict, // CSRF koruması
                Expires = DateTime.UtcNow.AddDays(7) // Süresi dolma
            };
            Response.Cookies.Append(AuthenticateData.CookiHeaderText, token, cookieOptions);
            return RedirectToAction("Index", "LessonPlan");

           
        }

        
    }
}
