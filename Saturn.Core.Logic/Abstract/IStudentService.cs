using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Abstract
{
    public interface IStudentService
    {
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);
        Task<IEnumerable<Student>> GetAll(Func<Student,bool> predicte);
        Task<IEnumerable<Student>> GetAll();

        Task RemoteAdd(Student student);
        Task RemoteUpdate(Student student);
        Task RemoteDelete(Student student);
        Task<IEnumerable<Student>> RemoteGetAll(Func<Student, bool> predicte);
        Task<IEnumerable<Student>> RemoteGetAll();

    }
}
