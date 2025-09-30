using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class AttendanceRaw
    {
        string _getdatestring;

        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? PcName { get; set; }
        public DateTime AttendanceTime { get; set; }
        [NotMapped]
        public string GetDateString {
            get
            {
                CultureInfo culture = new CultureInfo("tr-TR"); // Türkçe format
                _getdatestring = AttendanceTime.ToString("d MMMM yyyy dddd HH:mm", culture);
                return _getdatestring;
            }
           
        }
    }
}
