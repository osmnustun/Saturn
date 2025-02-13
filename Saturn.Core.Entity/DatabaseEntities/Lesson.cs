using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Lesson
    {
      
        private string startTime;

        [Key]
        public int LessonId { get; set; }
        public string? LessonName { get; set; }
        public DayOfWeek? DayOfLesson { get; set; }
       
        public string? EndTime { get; set; }     

        public User? Teacher { get; set; }
        public Guid? UserId { get; set; }
        public string? StartTime { get => startTime; set => startTime = value; }


        public  List<StudentsLessons>? Students { get; set; }
        public void Clear()
        {
            // Tüm özellikleri temizle
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                if (prop.CanWrite) // Yazılabilir mi kontrol et
                {
                    if (prop.PropertyType == typeof(string))
                        prop.SetValue(this, string.Empty); // String'leri boş yap
                    else if (prop.PropertyType.IsValueType)
                        prop.SetValue(this, Activator.CreateInstance(prop.PropertyType)); // Değer türlerini sıfırla
                }
            }

            // Tüm field'ları temizle
            foreach (FieldInfo field in this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!field.IsInitOnly) // Sadece okunur değilse sıfırla
                {
                    if (field.FieldType == typeof(string))
                        field.SetValue(this, string.Empty);
                    else if (field.FieldType.IsValueType)
                        field.SetValue(this, Activator.CreateInstance(field.FieldType));
                }
            }

        }
    }
}
