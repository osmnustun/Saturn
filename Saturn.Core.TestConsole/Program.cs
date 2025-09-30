using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saturn.Core.DataAccess.Concrete;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.Concrete;
using Saturn.Core.Logic.DependencyInjection;
using Saturn.Core.Logic.RemoteApi;
using Saturn.Core.Logic.Report;
using System;

namespace Saturn.Core.TestConsole
{
    internal class Program
    {
        readonly IAttendanceRawService _attendanceRawService;
        readonly IStudentService _studentService;
        readonly ILessonTimeTableServices _lessonTimeTableServices;
        readonly ApiService _apiService;
        public Program(IAttendanceRawService attendanceRawService, IStudentService studentService, ILessonTimeTableServices lessonTimeTableServices, ApiService apiService)
        {
            _attendanceRawService = attendanceRawService;
            _studentService = studentService;
            _lessonTimeTableServices = lessonTimeTableServices;
            _apiService = apiService;
        }
        static async Task Main(string[] args)
        {
            // 1. ServiceCollection oluştur
            var serviceCollection = new ServiceCollection();

            // 2. Tüm bağımlılıkları merkezi noktadan ekleyelim
            serviceCollection.GetServiceProvider(); // 🔥 Merkezi ekleme fonksiyonu çağrıldı
            serviceCollection.AddScoped<Program>(); // Program sınıfını da IoC Container'a ekledik
            //serviceCollection.AddDbContext<SaturnDbContext>(options =>
            //    options.UseMySQL("Server=192.168.1.150;user ID=saturn;Password=Saturn123.;Database=saturndb;"));

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
            //await TestVerisiEkle();

            var yoklamaListesi = new List<(string DersAdi, DateTime Tarih,bool yoklama)>
            {
                ("Matematik", new DateTime(2025, 9, 1),true),
                ("Matematik", new DateTime(2025, 9, 8), true),
                ("Fizik", new DateTime(2025, 9, 3), true),
                ("Fizik", new DateTime(2025, 9, 10), false),
                ("Fizik", new DateTime(2025, 9, 17), true)
            };

            var reportTools = new ReportTools();
            string path = reportTools.CreateStudentAttendanceReport(yoklamaListesi, "Öğrenci Yoklama Raporu");
            Console.WriteLine("Rapor oluşturuldu: " + path);


        }

        private async Task TestVerisiEkle()
        {
            var students = await _apiService.GetAsync<List<Student>>(DomainData.Domain + "student/getall", null);
            var faker = new Faker("tr");
            var attendanceList = new List<AttendanceRaw>();
            var random = new Random();

            for (int i = 0; i < 3000; i++)
            {
                // Rastgele öğrenci seç
                var student = students[random.Next(students.Count)];

                // Uygun gün bul (Pazartesi ve Pazar hariç)
                DateTime day;
                do
                {
                    day = faker.Date.Between(DateTime.Now.AddMonths(4), DateTime.Now).Date;
                } while (day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Monday);

                // 09:00 – 16:30 arası saat seç
                var start = new TimeSpan(16, 0, 0);
                var end = new TimeSpan(19, 30, 0);
                var range = end - start;
                var randomTime = start + TimeSpan.FromMinutes(random.Next((int)range.TotalMinutes));

                var attendance = new AttendanceRaw
                {
                    AttendanceTime = day + randomTime,
                    FullName = student.FullName,
                    PcName = faker.Internet.DomainName(),
                    Username = student.Username
                };

                attendanceList.Add(attendance);
            }
            foreach (var attendance in attendanceList)
            {
                await _apiService.PostAsync<AttendanceRaw, object>(DomainData.Domain + "attendance/attendanceraw", attendance);
                Console.WriteLine($"Added attendance for Full Name: {attendance.FullName}, Date Time: {attendance.AttendanceTime}");
            }
            Console.WriteLine("All attendance records have been added.");
        }
    }
}
