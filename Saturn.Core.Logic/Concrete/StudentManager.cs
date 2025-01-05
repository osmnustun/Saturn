using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Concrete
{
    public class StudentManager : IStudentService
    {
        readonly IStudentDataAccess _studentDataAccess;

        public StudentManager(IStudentDataAccess studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }

        public async Task Add(Student student)
        {
            await _studentDataAccess.CreateAsync(student);
            await _studentDataAccess.SaveChangesAsync();
        }

        public Task Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAll(Func<bool, Student> predicte)
        {
            throw new NotImplementedException();
        }

        public Task Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
