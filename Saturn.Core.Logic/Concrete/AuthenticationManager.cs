using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Entity.DTO;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Attributes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            return await _userManager.CreateAsync(user, password);

            // await _userManager.AddToRoleAsync(user, "Admin");
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
            roles.Add("admin");
            roles.Add("user");
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticateData.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(

                        issuer: AuthenticateData.Issuer,
                        audience: AuthenticateData.Audience,
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string ValidateToken(string token)
        {
            string secretKey = AuthenticateData.SecretKey;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            try
            {
                // Token doğrulama işlemi
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = AuthenticateData.Issuer,
                    ValidAudience = AuthenticateData.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                // Token'ı doğrula
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return ("Token geçerli. Veriler: " + principal.Identity.Name);
            }
            catch (SecurityTokenExpiredException)
            {
                return ("Token süresi dolmuş.");
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return ("Geçersiz token imzası.");
            }
            catch (Exception ex)
            {
                return ("Geçersiz token: " + ex.Message);
            }
        }

       
        public async Task<IEnumerable<User>> GetUsers()
        {
            var resault = await _userManager.Users.ToListAsync();
            return resault.ToList();
        }

        public async Task<string> CheckUser(UserDTO userDTO)
        {
            var user = await _userManager.FindByNameAsync(userDTO.UserName);
            if (user != null)
                if (await _userManager.CheckPasswordAsync(user, userDTO.Password))
                    return await GenerateJwtToken(userDTO);
            return "Doğrulama Yapılamadı, Kullanıcı yok!";

        }

       

      
    }
}
