using Microsoft.Extensions.DependencyInjection;
using Saturn.Core.Logic.DependencyInjection;

namespace Saturn.Core.Desktop.Teacher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var serviceProvider = new ServiceCollection()
                .GetServiceProvider()
                .AddScoped<frmMain>()
                .BuildServiceProvider();
            

            ApplicationConfiguration.Initialize();

            var frmMainService = serviceProvider.GetRequiredService<frmMain>();


            Application.Run(frmMainService);
        }
    }
}