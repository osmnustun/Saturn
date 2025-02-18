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
        readonly IStudentService _studentService;
        readonly ILessonTimeTableServices _lessonTimeTableServices;
        public Program(IAttendanceRawService attendanceRawService, IStudentService studentService, ILessonTimeTableServices lessonTimeTableServices)
        {
            _attendanceRawService = attendanceRawService;
            _studentService = studentService;
            _lessonTimeTableServices = lessonTimeTableServices;
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
            Random ran = new Random();
            var students = await _studentService.RemoteGetAll();
            var lessons = await _lessonTimeTableServices.GetAllRemote();
            foreach (var student in students)
            {
                //student.Groups = lessons.OrderBy(x => ran.Next()).Take(ran.Next(1,3))
                //    .Select(lesson => new StudentsLessons
                //    {
                //        StudentId = student.StudentId,
                //        LessonId = lesson.LessonId,
                //        Lesson = lesson
                //    }).ToList();

                student.BilsemNo = ran.Next(10000, 99999).ToString();
                await _studentService.RemoteUpdate(student);

                Console.WriteLine($"Öğrenci {student.FullName} güncellendi");
            }


            
        }
    }
}
