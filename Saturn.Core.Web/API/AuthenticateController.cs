using Microsoft.AspNetCore.Http;
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
           var resault =  await _authenticateService.CreateUser(new User()
            {
                UserName = userDTO.UserName,
                FullName=userDTO.FullName
                
            },
            userDTO.Password);

            var resaults= new List<string>();
            foreach (var r in resault.Errors)
            {
                resaults.Add(r.Description);
            }
            return resaults;
        }
        [HttpGet("users")]
        public async Task<List<User>> GetUsers()
        {
            return (List<User>)await _authenticateService.GetUsers();
        }

    }


}
