using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Entity.DatabaseEntities
{
    public class Student
    {
       
        [Key]
        public int StudentId { get; set; }
        public string? BilsemNo { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Class { get; set; }
        public List<StudentsLessons> Groups { get; set; }     

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
