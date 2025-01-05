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
        public StudentDataAccess(SaturnDbContext context) : base(context)
        {
        }
    }
}
