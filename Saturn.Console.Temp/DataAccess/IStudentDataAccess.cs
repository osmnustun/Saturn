using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Console.Temp.DataAccess
{
    public interface IStudentDataAccess
    {
        Task Add(Student student);
        Task Delete(Student student);
        Task Update(Student student);
        Task<IEnumerable<Student>> GetAll();
    }
}
