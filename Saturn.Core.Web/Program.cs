using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Saturn.Core.DataAccess.Concrete;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SaturnDbContext>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();
// JWT ile kimlik doðrulama yapýlandýrmasý
var jwtSetting = builder.Configuration.GetSection("jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSetting["Jwt:Issuer"],
            ValidAudience = jwtSetting["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["Jwt:SecretKey"]))
        };
    });
builder.Services.AddIdentity<User, UserRole>(
    options =>
    {
        // Parola yapýlandýrmasýný buraya ekleyebilirsiniz
        options.Password.RequireDigit = false; // Rakam gerektir
        options.Password.RequireLowercase = false; // Küçük harf gerektir
        options.Password.RequireUppercase = false; // Büyük harf gerektir
        options.Password.RequireNonAlphanumeric = false; // Alfasayýsal olmayan karakter gerektir
        options.Password.RequiredLength = 3; // Minimum 8 karakter
        options.Password.RequiredUniqueChars = 0; // En az bir benzersiz karakter
    }).AddEntityFrameworkStores<SaturnDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Kimlik doðrulama middleware'ini ekle
app.UseAuthorization();   // Yetkilendirme middleware'ini ekle


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
