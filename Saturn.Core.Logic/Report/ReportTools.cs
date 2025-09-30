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
                                        //columns.RelativeColumn((float)tableData.Max(item => (prop.GetValue(item)?.ToString()?.Length ?? 0)));
                                        columns.RelativeColumn();
                                      
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
    }
}
