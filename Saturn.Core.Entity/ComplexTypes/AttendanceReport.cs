using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.ComplexTypes
{
    public class AttendanceReport
    {
        public string BilsemNo { get; set; }
        public string username { get; set; }
        public string FullName { get; set; }       
        public string PcName { get; set; }
        public string AttendanceDateTime { get; set; }
    }
}
