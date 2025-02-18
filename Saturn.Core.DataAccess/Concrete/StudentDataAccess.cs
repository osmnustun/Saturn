using Microsoft.EntityFrameworkCore;
using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class StudentDataAccess : EfCoreRepository<Student, SaturnDbContext>, IStudentDataAccess
    {
        readonly SaturnDbContext _context;
        public StudentDataAccess(SaturnDbContext context) : base(context)
        {
            _context = context;
        }

        public async  Task<List<Student>> GetAllStudentWithGroupsAsync()
        {
            var resault= await _context.Students
                .Include( x => x.Groups)
                .ThenInclude(x => x.Lesson)
                .ToListAsync();

            return resault;
        }

        public async Task UpdateStudentWithGroups(Student student)
        {
            using (var context = _context)
            {
                var st = context.Students
                    .Include(x => x.Groups)
                    .FirstOrDefault(x => x.StudentId == student.StudentId);

                st.Groups = student.Groups;
                await context.SaveChangesAsync();
            }
        }
    }
}
