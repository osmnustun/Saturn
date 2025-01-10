using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Student
    {
        private ICollection<Lesson> _groups;
        [Key]
        public int StudentId { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Class { get; set; }
        public ICollection<Lesson>? Groups
        {
            get
            {
                return _groups ??= new List<Lesson>();
            }
            set
            {
                _groups = value;
            }
        }
        public int GroupId { get; set; }


    }
}
