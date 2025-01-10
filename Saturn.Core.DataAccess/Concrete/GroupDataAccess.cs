using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class GroupDataAccess : EfCoreRepository<Lesson, SaturnDbContext>, IGroupDataAccess
    {
        public GroupDataAccess(SaturnDbContext context) : base(context)
        {
        }
    }
}
