using Google.Protobuf.WellKnownTypes;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Report
{
    public class ReportTools
    {
        public string GeneratePdfReport<T>(IEnumerable<T> data, params string[] fields)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            if (data == null)
                throw new ArgumentException("Data cannot be empty.");

            var properties = typeof(T).GetProperties()
                .Where(p => fields.Length == 0 || fields.Contains(p.Name))
                .ToList();

            if (properties.Count == 0)
                throw new ArgumentException("No valid fields to display.");

            string fileName = $"report_{Guid.NewGuid()}.pdf";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.Header().Text("Rapor").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in properties)
                            {
                                columns.RelativeColumn();
                            }
                        });

                        table.Header(header =>
                        {
                            foreach (var prop in properties)
                            {
                                header.Cell().Border(1).Padding(5).Text(prop.Name).Bold();
                            }
                        });

                        foreach (var item in data)
                        {
                            foreach (var prop in properties)
                            {
                                table.Cell().Text(prop.GetValue(item)?.ToString() ?? "");
                            }
                        }
                    });

                });

            }).GeneratePdf(filePath);

            return filePath;
        }

    
        // Generic fonksiyon
        public string CreatePdfWithDynamicTables<T>(List<List<T>> data, string[] fields, string[] headerText, string reportHeader)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            if(headerText.Length == 0)
               headerText=fields;

            if (data == null || data.Count == 0)
                    throw new ArgumentException("Data cannot be empty or count = 0.");

            var properties = data[0][0].GetType().GetProperties()
                .Where(p => fields.Length == 0 || fields.Contains(p.Name))
                .ToList();

            if (properties.Count == 0)
                throw new ArgumentException("No valid fields to display.");

            string fileName = $"report_{Guid.NewGuid()}.pdf";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);

            Document.Create(container =>
            {
                foreach (var tableData in data)
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(15);
                        page.DefaultTextStyle(x => x.FontSize(11));
                        page.Header().Text(reportHeader).FontSize(14).Bold().AlignCenter();
                        page.Content()
                            .Table(table =>
                            {
                         
                                table.ColumnsDefinition(columns =>
                                {
                                    foreach (var prop in properties)
                                    {
                                        columns.RelativeColumn((float)tableData.Max(item => (prop.GetValue(item)?.ToString()?.Length ?? 0)));
                                      
                                    }
                                });

                                table.Header(header =>
                                {
                                    foreach (var prop in headerText)
                                    {
                                        header.Cell().BorderBottom(1).Padding(2).Text(prop).Bold();
                                    }
                                });

                                foreach (var item in tableData)
                                {
                                    foreach (var prop in properties)
                                    {
                                        table.Cell().BorderBottom(1).PaddingVertical(2).Text(prop.GetValue(item)?.ToString() ?? "");
                                    }
                                }
                            });
                    });
                }
            }).GeneratePdf(filePath);

            return filePath;
        }

       
        public string CreateStudentAttendanceReport(List<(string DersAdi, DateTime Tarih, bool Yoklama)> attendanceData, string reportHeader)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

           // if (attendanceData == null || attendanceData.Count == 0)
                //throw new ArgumentException("Attendance data cannot be empty.");

            var lessons = attendanceData.Select(a => a.DersAdi).Distinct().OrderBy(d => d).ToList();
            string fileName = $"attendance_{Guid.NewGuid()}.pdf";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(10));
                    page.Header().Text(reportHeader).FontSize(16).Bold().AlignCenter();

                    page.Content().Column(col =>
                    {
                        foreach (var lesson in lessons)
                        {
                            var lessonRecords = attendanceData
                                .Where(a => a.DersAdi == lesson)
                                .OrderBy(a => a.Tarih)
                                .ToList();

                            col.Item().Border(1).Padding(10).Column(lessonCol =>
                            {
                                lessonCol.Item().Text(lesson).FontSize(13).Bold().Underline();

                                if (lessonRecords.Count == 0)
                                {
                                    lessonCol.Item().Text("Bu derse ait yoklama kaydı bulunmamaktadır.")
                                        .Italic().FontColor(Colors.Grey.Darken1);
                                }
                                else
                                {
                                    var dates = lessonRecords.Select(r => r.Tarih.Date).Distinct().OrderBy(d => d).ToList();

                                    // Tarihleri parçalara böl: her tabloda max 20 tarih
                                    int chunkSize = 40;
                                    for (int start = 0; start < dates.Count; start += chunkSize)
                                    {
                                        var chunkDates = dates.Skip(start).Take(chunkSize).ToList();

                                        lessonCol.Item().Table(table =>
                                        {
                                            // Dinamik sütun genişliği
                                            table.ColumnsDefinition(columns =>
                                            {
                                                columns.ConstantColumn(50); // Etiket sütunu
                                                var dateColumnWidth = Math.Max(20, 700 / chunkDates.Count); // max genişlik 700
                                                foreach (var _ in chunkDates)
                                                    columns.ConstantColumn(dateColumnWidth);
                                            });

                                            // Başlık satırı
                                            table.Cell().Row(1).Column(1).AlignCenter().Text("");
                                            for (int i = 0; i < chunkDates.Count; i++)
                                            {
                                                table.Cell().Row(1).Column((uint)(i + 2)).Border(1).Padding(1)                                               
                                                    .AlignCenter()
                                                    .RotateLeft()
                                                    .Text(chunkDates[i].ToString("dd.MM.yyyy dddd"))
                                                    .FontSize(9);
                                            }

                                            // "Geldi" satırı
                                            table.Cell().Row(2).Column(1).BorderBottom(1).Text("Geldi");
                                            for (int i = 0; i < chunkDates.Count; i++)
                                            {
                                                var rec = lessonRecords.FirstOrDefault(r => r.Tarih.Date == chunkDates[i]);
                                                bool geldi = rec != default && rec.Yoklama;
                                                table.Cell().Row(2).Column((uint)(i + 2)).Border(1).Padding(1)
                                                    .AlignCenter()
                                                    .Text(geldi ? "✔" : "")
                                                    .FontColor(geldi ? Colors.Green.Medium : Colors.Black)
                                                    .SemiBold();
                                            }

                                            // "Gelmedi" satırı
                                            table.Cell().Row(3).Column(1).BorderBottom(1).Text("Gelmedi");
                                            for (int i = 0; i < chunkDates.Count; i++)
                                            {
                                                var rec = lessonRecords.FirstOrDefault(r => r.Tarih.Date == chunkDates[i]);
                                                bool gelmedi = rec != default && !rec.Yoklama;
                                                table.Cell().Row(3).Column((uint)(i + 2)).Border(1).Padding(1)
                                                    .AlignCenter()
                                                    .Text(gelmedi ? "X" : "")
                                                    .FontColor(gelmedi ? Colors.Red.Medium : Colors.Black)
                                                    .SemiBold();
                                            }
                                        });

                                        lessonCol.Item().PaddingBottom(10); // tablo alt boşluk
                                    }
                                }
                            });

                            col.Item().PaddingBottom(20); // dersler arası boşluk
                        }
                    });

                    page.Footer().AlignRight().Text(x =>
                    {
                        x.Span("Oluşturulma: ").SemiBold();
                        x.Span(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                    });
                });
            }).GeneratePdf(filePath);

            return filePath;
        }




    }
}
