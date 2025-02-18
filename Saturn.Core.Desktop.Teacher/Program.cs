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
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(frmMainService);
        }

        private static void Application_ThreadException(object sender,ThreadExceptionEventArgs e)
        {
            LogError(e.Exception);
            MessageBox.Show("Beklenmedik bir hata oluþtu.\n" + e.Exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Kritik bir hata oluþtu.\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LogError(Exception ex)
        {
            // Hatalarý bir dosyaya veya veritabanýna kaydetme
           File.AppendAllText("errorlog.txt", $"{DateTime.Now}: {ex}\n");
        }
    }
}