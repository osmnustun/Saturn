using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Console.Temp.DataAccess
{
    public interface IAntendanceDataAccess
    {
        Task Add(Attendance attendance);
        Task Delete(Attendance attendance);
        Task Update(Attendance attendance);
        Task<IEnumerable<Attendance>> GetAll();
    }
}
