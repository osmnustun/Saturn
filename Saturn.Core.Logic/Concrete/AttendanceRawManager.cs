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
    public class AttendanceRawManager : IAttendanceRawService
    {
        readonly IAttendanceRawDataAccess _attendanceDataAccess;

        public AttendanceRawManager(IAttendanceRawDataAccess attendanceDataAccess)
        {
            _attendanceDataAccess = attendanceDataAccess;
        }

        public async Task Add(AttendanceRaw attendanceRaw)
        {
            await _attendanceDataAccess.CreateAsync(attendanceRaw);
            await _attendanceDataAccess.SaveChangesAsync();
        }

        public Task Delete(AttendanceRaw attendanceRaw)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AttendanceRaw>> GetAll(Func<AttendanceRaw, bool> predicte)
        {
            throw new NotImplementedException();
        }

        public Task Update(AttendanceRaw attendanceRaw)
        {
            throw new NotImplementedException();
        }
    }
}
