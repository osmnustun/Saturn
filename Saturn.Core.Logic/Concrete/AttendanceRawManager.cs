using Saturn.Core.DataAccess.Abstract;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;
using Saturn.Core.Logic.RemoteApi;
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
        readonly ApiService _apiService;
        public AttendanceRawManager(IAttendanceRawDataAccess attendanceDataAccess, ApiService apiService)
        {
            _attendanceDataAccess = attendanceDataAccess;
            _apiService = apiService;
        }

        public async Task Add(AttendanceRaw attendanceRaw)
        {
            await _attendanceDataAccess.CreateAsync(attendanceRaw);
            await _attendanceDataAccess.SaveChangesAsync();
        }

        public async Task Delete(AttendanceRaw attendanceRaw)
        {
              _attendanceDataAccess?.DeleteAsync(attendanceRaw);

        }

        public async Task<IEnumerable<AttendanceRaw>> GetAll(Func<AttendanceRaw, bool> predicte)
        {
           return await _attendanceDataAccess.GetAllAsync(predicte);
        }

        public async Task<IEnumerable<AttendanceRaw>> GetAll()
        {
            return await _attendanceDataAccess.GetAllAsync();
        }

        public async Task<IEnumerable<AttendanceRaw>> GetAllRemote()
        {
            var resault = await _apiService.GetAsync<List<AttendanceRaw>>(DomainData.Domain + "attendance/getattendanceraw", "");
            return resault;
        }

        public async Task RemoteAdd(AttendanceRaw attendance)
        {
            await _apiService.PostAsync<AttendanceRaw, AttendanceRaw>(DomainData.Domain + "attendance/attendanceraw", attendance);
        }

        public async Task Update(AttendanceRaw attendanceRaw)
        {
            _attendanceDataAccess.UpdateAsync(attendanceRaw);
            await _attendanceDataAccess.SaveChangesAsync();
        }
    }
}
