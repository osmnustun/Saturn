using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string? Branch { get; set; }
        
      
    }
}
