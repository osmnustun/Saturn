using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class StudentsLessons
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
