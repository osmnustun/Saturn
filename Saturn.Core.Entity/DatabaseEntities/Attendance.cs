using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public ICollection<Student>? Students { get; set; }
        public int StudentId { get; set; }




    }
}
