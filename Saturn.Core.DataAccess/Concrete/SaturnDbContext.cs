
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class SaturnDbContext:IdentityDbContext<User,UserRole,string>
    {
       
        public SaturnDbContext(DbContextOptions<SaturnDbContext> options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {

                
            }
          
        }
        //static readonly string connectionString = "Server = localhost;user ID= silivribilsem_com_saturn; Password =X2kkPrV10kwqfs#e7;Database=silivribilsem_com_saturndb;";// For product

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     //optionsBuilder.UseSqlite("Data Source=C:\\Users\\" + Environment.UserName + "\\SaturnDatabase.db");
        //     optionsBuilder.UseMySQL(connectionString);
        // }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Groups { get; set; }
        public DbSet<AttendanceRaw> AttendanceRaws { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

      
    }
}
