﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRawService _attendanceRawService;

        public AttendanceController(IAttendanceRawService attendanceRawService)
        {
            _attendanceRawService = attendanceRawService;
        }

        [HttpPost("attendanceraw")]
        public async Task<IActionResult> AddAttendance([FromBody] AttendanceRaw Attendance)
        {
            if (Attendance == null)
                return NotFound();
           // Attendance.AttendanceTime = DateTime.Now;   
            await _attendanceRawService.Add(Attendance);
            return Ok();

        }

        [HttpGet("getattendanceraw")]
        public async Task<IActionResult> GetAttendance()
        {
            
           var resault= await _attendanceRawService.GetAll();
            return Ok(resault);

        }
    }
}
