using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.Logic.Abstract
{
    public interface ILessonTimeTableServices
    {
        Task Add(Lesson lessonTimeTable);
        Task Delete(Lesson lessonTimeTable);
        Task<IEnumerable<Lesson>> GetAll(Func<Lesson, bool> predicte);
        Task<IEnumerable<Lesson>> GetAll();
        Task<Lesson> Update(Lesson lessonTimeTable);

        Task AddRemote(Lesson lessonTimeTable);
        Task DeleteRemote(Lesson lessonTimeTable);
        Task<IEnumerable<Lesson>> GetAllRemote(Func<Lesson, bool> predicte);
        Task<IEnumerable<Lesson>> GetAllRemote();
        Task<Lesson> UpdateRemote(Lesson lessonTimeTable);

       Task< List<Lesson>> GetAllGroups();

    }
}
