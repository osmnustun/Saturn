using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Attendance
    {
        private string? dateString;
        public int? Id { get; set; }
        public string DateString
        {
            get
            {
                CultureInfo culture = new CultureInfo("tr-TR"); // Türkçe format
                dateString = Date.ToString("d MMMM yyyy dddd", culture);
                return dateString;
            }
            set => dateString = value;
        }
        public DateTime Date { get; set; }

        public int StudentCount { get; set; }


    }
}
