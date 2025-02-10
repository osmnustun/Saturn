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
    public class LessonTimeTablesManager : ILessonTimeTableServices
    {
        readonly ApiService _apiService;
        readonly IGroupDataAccess _groupDataAccess;

        public LessonTimeTablesManager(ApiService apiService, IGroupDataAccess groupDataAccess)
        {
            _apiService = apiService;
            _groupDataAccess = groupDataAccess;
        }

        public async Task Add(Lesson lessonTimeTable)
        {
            await _groupDataAccess.CreateAsync(lessonTimeTable);
            await _groupDataAccess.SaveChangesAsync();
        }

        public async Task AddRemote(Lesson lessonTimeTable)
        {
           await  _apiService.PostAsync<Lesson, Lesson>(DomainData.Domain + "LessonTimeTables/add", lessonTimeTable);
        }

        public Task Delete(Lesson lessonTimeTable)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRemote(Lesson lessonTimeTable)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lesson>> GetAll(Func<Lesson, bool> predicte)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _groupDataAccess.GetAllAsync();
        }

        public Task<IEnumerable<Lesson>> GetAllRemote(Func<Lesson, bool> predicte)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lesson>> GetAllRemote()
        {
           var resault =await _apiService.GetAsync<List<Lesson>>(DomainData.Domain + "LessonTimeTables/getall", "");
            return resault;
        }

        public Task<Lesson> Update(Lesson lessonTimeTable)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> UpdateRemote(Lesson lessonTimeTable)
        {
            throw new NotImplementedException();
        }
    }
}
