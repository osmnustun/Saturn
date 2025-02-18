using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Abstract
{
    public interface IStudentDataAccess : IEfCoreDataAccess<Student>
    {
       Task<List<Student>> GetAllStudentWithGroupsAsync();
        Task UpdateStudentWithGroups(Student student);
    }
}
