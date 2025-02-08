using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saturn.Net.Student
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;  // Pencereyi gizler
        const int SW_SHOW = 5;  // Pencereyi göster         
        static async Task Main(string[] args)
        {
            IntPtr hWnd = GetConsoleWindow();
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, SW_HIDE);
            }
            // Kullanıcı bilgilerini al
            string userName = Environment.UserName; // Kullanıcı adı
            string machineName = Environment.MachineName; // Bilgisayar adı
            string domainName = GetADFullName(Environment.UserName); // Active Directory Full Name (tam ad)

            // Kullanıcı bilgilerini ekrana yazdır
            Console.WriteLine($"Kullanıcı Adı: {userName}");
            Console.WriteLine($"Bilgisayar Adı: {machineName}");
            Console.WriteLine($"Tam Ad (AD Full Name): {domainName}");

            // JSON dönüştürücüyü kullanarak JSON string oluştur
            var jsonPayload = JsonConvert.SerializeObject(new AttendanceRaw()
            {
                FullName = domainName,
                PcName = machineName,
                Username = userName
            });

            // JSON içeriğini ekrana yazdır
            Console.WriteLine("JSON Payload:");
            Console.WriteLine(jsonPayload);

            // API adresi (değiştirmeniz gerekebilir)
            //string apiUrl = ReadApiUrlFromFile("api_url.txt");
            string apiUrl = "http://www.saturn.edu/api/attendance/attendanceraw";

            if (string.IsNullOrEmpty(apiUrl))
            {
                Console.WriteLine("API adresi dosyadan okunamadı!");
                return;
            }

            // HTTP Client ile POST isteği gönder
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // JSON içeriğini oluştur
                    StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // POST isteği yap
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Yanıtı kontrol et
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Bilgiler başarıyla gönderildi.");
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"API Yanıtı: {responseContent}");
                        if (hWnd != IntPtr.Zero)
                        {
                            ShowWindow(hWnd, SW_SHOW); // Konsolu tekrar göster
                        }
                        string[] asciiOK = {
                                               "  OOO   K   K   ",
                                               " O   O  K  K                              =",
                                               " O   O  K K                             =",
                                               " O   O  KK                           =",
                                               " O   O  K K                       =",
                                               " O   O  K  K            ===     =",
                                               "  OOO   K   K              ==="
                                           };

                        for (int i = 0; i < asciiOK.Length; i++)
                        {
                            Console.SetCursorPosition(5, 10 + i); // Konsolda ortalamak için
                            Console.WriteLine(asciiOK[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Hata: {response.StatusCode}");
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Hata Detayı: {errorContent}");
                        if (hWnd != IntPtr.Zero)
                        {
                            ShowWindow(hWnd, SW_SHOW); // Konsolu tekrar göster
                        }
                        string[] asciiFAILX = {
                                                 "FFFF   AAAAA  III  L           X   X ",
                                                 "F      A   A   I   L            X X  ",
                                                 "FFF    AAAAA   I   L             X   ",
                                                 "F      A   A   I   L            X X  ",
                                                 "F      A   A  III  LLLLL       X   X "
                                             };

                        for (int i = 0; i < asciiFAILX.Length; i++)
                        {
                            Console.SetCursorPosition(5, 10 + i); // Yazıyı ortalamak için
                            Console.WriteLine(asciiFAILX[i]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, SW_SHOW); // Konsolu tekrar göster
                    }
                    string[] asciiFAILX = {
                                                 "FFFF   AAAAA  III  L           X   X ",
                                                 "F      A   A   I   L            X X  ",
                                                 "FFF    AAAAA   I   L             X   ",
                                                 "F      A   A   I   L            X X  ",
                                                 "F      A   A  III  LLLLL       X   X "
                                             };

                    for (int i = 0; i < asciiFAILX.Length; i++)
                    {
                        Console.SetCursorPosition(5, 10 + i); // Yazıyı ortalamak için
                        Console.WriteLine(asciiFAILX[i]);
                    }
                }
            }

            Thread.Sleep(3000);
        }

        // Kullanıcının Active Directory'deki Full Name bilgisini almak için yardımcı metot
        static string GetADFullName(string userName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                {
                    UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);
                    return user?.DisplayName ?? "Full Name alınamadı";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Active Directory'den kullanıcı bilgileri alınırken bir hata oluştu: {ex.Message}");
                return "Full Name alınamadı";
            }
        }

        static string ReadApiUrlFromFile(string filePath)
        {
            try
            {
                // Dosyayı oku ve satırdaki ilk satırı döndür
                return File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dosya okuma hatası: {ex.Message}");
                return null;
            }
        }
    }

    internal class AttendanceRaw
    {
        public AttendanceRaw()
        {
        }

        public string FullName { get; set; }
        public string PcName { get; set; }
        public string Username { get; set; }
    }
}
