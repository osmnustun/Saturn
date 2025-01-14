using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Saturn.Core.Logic.Attributes
{
    public class AuthorizeClientAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _requiredRoles; // Birden fazla rol desteği ekledik

        // Constructor, birden fazla rol kabul ediyor
        public AuthorizeClientAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Token'ı önce Authorization header'dan, sonra cookie'den al
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                // Eğer Authorization header yoksa cookie'yi kontrol et
                token = context.HttpContext.Request.Cookies[AuthenticateData.CookiHeaderText];
            }

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectResult(AuthenticateData.LoginPage); // Token bulunamazsa giriş sayfasına yönlendir
                return;
            }

            // Token doğrulama işlemleri
            try
            {
                var validatedToken = ValidateToken(token); // Kendi token doğrulama metodunuz
                var claimsPrincipal = GetClaimsPrincipal(validatedToken); // Kendi claims çözümleme metodunuz
                context.HttpContext.User = claimsPrincipal;
            }
            catch (Exception)
            {
                context.Result = new RedirectResult(AuthenticateData.LoginPage);  // Ayrıca giriş sayfasına yönlendir
                return;
            }

            // Eğer belirli bir rol kontrolü gerekiyorsa
            if (_requiredRoles.Length > 0 && !_requiredRoles.Any(role => context.HttpContext.User.IsInRole(role)))
            {
                // Kullanıcının role göre yetkilendirme yapılmazsa
                context.Result = new RedirectResult(AuthenticateData.LoginPage); // Yetkilendirme başarısızsa 403 döndür
            }
        }

        private SecurityToken ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = AuthenticateData.SecretKey; // Secret key'i yapılandırmadan al
            var key = Encoding.UTF8.GetBytes(secretKey);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer=AuthenticateData.Issuer,
                ValidAudience=AuthenticateData.Audience,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            return validatedToken;
        }

        private ClaimsPrincipal GetClaimsPrincipal(SecurityToken token)
        {
            var jwtToken = token as JwtSecurityToken;
            if (jwtToken == null)
                throw new SecurityTokenException("Invalid token");

            var claims = jwtToken.Claims;
            var identity = new ClaimsIdentity(claims, "jwt");
            return new ClaimsPrincipal(identity);
        }
    }
}
