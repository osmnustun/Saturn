using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class AttendaceRawDataAccess : EfCoreRepository<AttendanceRaw, SaturnDbContext>, IAttendanceRawDataAccess
    {
        public AttendaceRawDataAccess(SaturnDbContext context) : base(context)
        {
        }
    }
}
