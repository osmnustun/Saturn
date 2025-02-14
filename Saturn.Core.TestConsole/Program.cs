using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Concrete;
using Saturn.Core.Logic.DependencyInjection;

namespace Saturn.Core.TestConsole
{
    internal class Program
    {
        readonly IAttendanceRawService _attendanceRawService;
        public Program(IAttendanceRawService attendanceRawService)
        {
            _attendanceRawService = attendanceRawService;
        }
        static async Task Main(string[] args)
        {
            // 1. ServiceCollection oluştur
            var serviceCollection = new ServiceCollection();

            // 2. Tüm bağımlılıkları merkezi noktadan ekleyelim
            serviceCollection.GetServiceProvider(); // 🔥 Merkezi ekleme fonksiyonu çağrıldı
            serviceCollection.AddScoped<Program>(); // Program sınıfını da IoC Container'a ekledik

            // 3. ServiceProvider oluştur
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // 4. Program sınıfını IoC Container'dan al
            var program = serviceProvider.GetRequiredService<Program>();

            // 5. Çalıştır
            await program.Run();

            Console.ReadLine(); 
        }

        private async Task Run()
        {
            var faker = new Faker<AttendanceRaw>()
                  .RuleFor(x => x.PcName, f => f.Name.JobTitle())
                  .RuleFor(x => x.Username, f => f.Internet.UserName())
                  .RuleFor(x => x.FullName, f => f.Name.FullName())
                  .RuleFor(x => x.AttendanceTime, f => f.Date.Past(1,new DateTime(2025,12,31)));
            var liste = faker.Generate(20000);
            foreach (var item in liste)
            {
               await _attendanceRawService.RemoteAdd(item);
                Console.WriteLine($"{item.Username}     {item.AttendanceTime.ToLongDateString()} eklendi");

            }

        }
    }
}
