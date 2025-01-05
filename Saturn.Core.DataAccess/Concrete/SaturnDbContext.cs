using Microsoft.EntityFrameworkCore;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class SaturnDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\" + Environment.UserName + "\\SaturnDatabase.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AttendanceRaw> AttendanceRaws { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
