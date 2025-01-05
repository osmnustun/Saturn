using Microsoft.EntityFrameworkCore;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Console.Temp.DataAccess
{
    public class StudentDataAccess : IStudentDataAccess
    {
        SaturnContext context= new SaturnContext();
        public async Task Add(Student student)
        {
          await context.Students.AddAsync(student);
          await context.SaveChangesAsync(); 
        }

        public async Task Delete(Student student)
        {
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
           var s= await context.Students.ToListAsync();
            return s;
        }

        public async Task Update(Student student)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }
    }
}
