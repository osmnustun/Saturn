using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.DataAccess.Concrete;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Concrete;
using Saturn.Core.Logic.RemoteApi;
using Saturn.Core.Logic.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.DependencyInjection
{
    public static class ServiceProviderApp
    {
        public static IServiceCollection GetServiceProvider(this IServiceCollection services)
        {
            services.AddDbContext<SaturnDbContext>();
            services.AddScoped<IStudentDataAccess, StudentDataAccess>();
            services.AddScoped<IGroupDataAccess, GroupDataAccess>();
            services.AddScoped<IAttendaceDataAccess, AttendanceDataAccess>();
            services.AddScoped<IAttendanceRawDataAccess, AttendaceRawDataAccess>();
            services.AddScoped<IAttendanceRawService, AttendanceRawManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<ILessonTimeTableServices, LessonTimeTablesManager>();
            services.AddScoped<ApiService>();
            services.AddScoped<ReportTools>();
            return services;

        }
    }
}
