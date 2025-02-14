using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Abstract
{
    public interface IAttendanceRawService
    {
        Task Add(AttendanceRaw attendanceRaw);
        Task Update(AttendanceRaw attendanceRaw);
        Task Delete(AttendanceRaw attendanceRaw);
        Task<IEnumerable<AttendanceRaw>> GetAll(Func<AttendanceRaw, bool> predicte);
        Task<IEnumerable<AttendanceRaw>> GetAll();
        Task<IEnumerable<AttendanceRaw>> GetAllRemote();
        Task RemoteAdd(AttendanceRaw attendance);
    }
}
