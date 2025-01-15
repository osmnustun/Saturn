﻿using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Saturn.Core.Entity.DatabaseEntities;
using System.DirectoryServices.AccountManagement;
using System.Text;

namespace Saturn.Core.ConsoleApp.Student
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
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
            string apiUrl = ReadApiUrlFromFile("api_url.txt");

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
                    }
                    else
                    {
                        Console.WriteLine($"Hata: {response.StatusCode}");
                        string errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Hata Detayı: {errorContent}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                }
            }

            Console.ReadLine();
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
}
