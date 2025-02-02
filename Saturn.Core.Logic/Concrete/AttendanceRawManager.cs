﻿using Saturn.Core.DataAccess.Abstract;
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

        public async Task Update(AttendanceRaw attendanceRaw)
        {
            _attendanceDataAccess.UpdateAsync(attendanceRaw);
            await _attendanceDataAccess.SaveChangesAsync();
        }
    }
}
