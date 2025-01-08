using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.DTO;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Web.API
{
    [Route("api/usermanager")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticateService;
       
        public AuthenticateController(IAuthenticationService authenticateService)
        {
            _authenticateService = authenticateService;

        }
        [HttpPost("adduser")]
        public async Task<List<string>> AddUser([FromBody] UserDTO userDTO)
        {
            var resault = await _authenticateService.CreateUser(new User()
            {
                UserName = userDTO.UserName,
                FullName = userDTO.FullName

            },
             userDTO.Password);

            var resaults = new List<string>();
            foreach (var r in resault.Errors)
            {
                resaults.Add(r.Description);
            }
            return resaults;

        }

        [HttpPost("addrole")]
        public async Task<IdentityResult> AddRole([FromBody] UserRoleDTO userRoleDTO)
        {
            var userRole = new UserRole()
            {
                Name = userRoleDTO.Name,
                NormalizedName = userRoleDTO.NormalizedName,
                Description = userRoleDTO.Description,
                IsActive = userRoleDTO.IsActive

            };

            return await _authenticateService.AddRole(userRole);
        }

        [HttpGet("users")]
        public async Task<List<User>> GetUsers()
        {
            return (List<User>)await _authenticateService.GetUsers();
        }

        [HttpPost("gettoken")]  
        public  async Task<string> GenerateToken(UserDTO userDTO)
        {
           return await _authenticateService.GenerateJwtToken(userDTO);
        }

        [HttpPost("validatetoken")]
        public string ValidateToken(string token)
        {
            return   _authenticateService.ValidateToken(token);
        }

    }


}
