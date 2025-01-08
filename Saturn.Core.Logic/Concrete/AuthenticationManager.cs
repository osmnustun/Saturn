using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.DTO;
using Saturn.Core.Logic.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        public AuthenticationManager(IConfiguration configuration, UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddRole(UserRole rolname)
        {        
          return await _roleManager.CreateAsync(rolname);
        }

        public async Task<IdentityResult> CreateUser(User user, string password)
        {
             await _userManager.CreateAsync(user,password);
            
            return await _userManager.AddToRoleAsync(user, "Admin");
        }
        public async Task<string> GenerateJwtToken(UserDTO userDTO)
        {
            User user = await _userManager.FindByNameAsync(userDTO.UserName);
            
            var cp = _userManager.CheckPasswordAsync(user, userDTO.Password);
            if (!cp.Result)
                return "Username or Password Error";
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             
          
        };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           var resault = await _userManager.Users.ToListAsync();
           return resault.ToList();
        }
    }
}
