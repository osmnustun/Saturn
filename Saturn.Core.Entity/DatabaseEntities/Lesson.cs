using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Lesson
    {
        private ICollection<Student>? _students;
        [Key]
        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public DayOfWeek DayOfLesson { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public ICollection<Student> Students
        {
            get
            {
                // Eğer koleksiyon null ise boş bir liste döndür
                return _students ??= new List<Student>();
            }
            set
            {
                _students = value;
            }
        }       
        public int StudentId { get; set; }
        public User Teacher { get; set; }
        public Guid UserId { get; set; }

    }
}
