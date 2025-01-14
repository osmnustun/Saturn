

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.DataAccess.Concrete;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Attributes;
using Saturn.Core.Logic.Concrete;
using Saturn.Core.Logic.RemoteApi;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("SaturnDb");
builder.Services.AddDbContext<SaturnDbContext>(opt =>
{
    opt.UseMySQL(connectionString);
});
builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();
builder.Services.AddScoped<IStudentDataAccess, StudentDataAccess>();
builder.Services.AddScoped<IAttendanceRawService,AttendanceRawManager>();
builder.Services.AddScoped<IAttendaceDataAccess,AttendanceDataAccess>();
builder.Services.AddScoped<IAttendanceRawDataAccess, AttendaceRawDataAccess>();
builder.Services.AddScoped<ApiService>();


builder.Services.AddIdentity<User, UserRole>(
    options =>
    {        // Parola yapýlandýrmasýný buraya ekleyebilirsiniz
        options.Password.RequireDigit = false; // Rakam gerektir
        options.Password.RequireLowercase = false; // Küçük harf gerektir
        options.Password.RequireUppercase = false; // Büyük harf gerektir
        options.Password.RequireNonAlphanumeric = false; // Alfasayýsal olmayan karakter gerektir
        options.Password.RequiredLength = 3; // Minimum 8 karakter
        options.Password.RequiredUniqueChars = 0; // En az bir benzersiz karakter
    })
    .AddEntityFrameworkStores<SaturnDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers();


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

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<TokenValidationMiddleware>();
app.Use(async (context, next) =>
{
    Console.WriteLine("Request path: " + context.Request.Path);
    await next();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
