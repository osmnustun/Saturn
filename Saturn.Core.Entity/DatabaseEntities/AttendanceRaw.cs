using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class AttendanceRaw
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? PcName { get; set; }
        public DateTime AttendanceTime { get; set; }
    }
}
