using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.DTO;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AdminController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize]
        public IActionResult Index()
        
        {
            return View("Dashboard");
        }

        [HttpPost]
        public async  Task<IActionResult> CheckUser(UserDTO userDTO)
        {
            var token = await _authenticationService.CheckUser(userDTO);
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true, // Çerez sadece backend'de kullanılabilir
                Secure = true,   // HTTPS bağlantısı gerektirir
                Expires = DateTime.UtcNow.AddMinutes(2)

            });
            return RedirectToAction("Index");

           
        }


    }
}
