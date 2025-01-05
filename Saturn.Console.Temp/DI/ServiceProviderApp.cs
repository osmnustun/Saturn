using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saturn.Console.Temp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Console.Temp.DI
{
    public static class ServiceProviderApp
    {
        public static ServiceProvider GetServices()
        {
            var serviceProvider= new ServiceCollection()
                .AddDbContext<SaturnContext>()
                .AddScoped<IStudentDataAccess,StudentDataAccess>()
                .BuildServiceProvider();
            return serviceProvider;            
        }
    }
}
