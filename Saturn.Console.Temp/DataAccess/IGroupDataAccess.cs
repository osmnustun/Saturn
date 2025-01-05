using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Console.Temp.DataAccess
{
    public interface IGroupDataAccess
    {
        Task Add(Group group);
        Task Delete(Group group);
        Task Update(Group group);
        Task<IEnumerable<Group>> GetAll();

    }
}
