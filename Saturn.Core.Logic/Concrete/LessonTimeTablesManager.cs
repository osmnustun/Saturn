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

        public async Task Delete(Lesson lessonTimeTable)
        {
            await _groupDataAccess.DeleteAsync(lessonTimeTable);
            await _groupDataAccess.SaveChangesAsync();
        }

        public async Task DeleteRemote(Lesson lessonTimeTable)
        {
            await _apiService.PostAsync<Lesson, Lesson>(DomainData.Domain + "LessonTimeTables/remove", lessonTimeTable);
        }

        public async Task<IEnumerable<Lesson>> GetAll(Func<Lesson, bool> predicte)
        {
            return await _groupDataAccess.GetAllAsync(predicte);
           
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _groupDataAccess.GetAllAsync();
        }

        public async Task<List<Lesson>> GetAllGroups()
        {
            var resault= await _apiService.GetAsync<IEnumerable<Lesson>>(DomainData.Domain + "LessonTimeTables/getall", "");
            return (List<Lesson>)resault;
            
        }

        public  async Task<IEnumerable<Lesson>> GetAllRemote(Func<Lesson, bool> predicte)
        {
          return await _apiService.GetAsync<IEnumerable<Lesson>>(DomainData.Domain + "LessonTimeTables/getall","");
        }

        public async Task<IEnumerable<Lesson>> GetAllRemote()
        {
           var resault =await _apiService.GetAsync<List<Lesson>>(DomainData.Domain + "LessonTimeTables/getall", "");
            return resault;
        }

        public async Task<Lesson> Update(Lesson lessonTimeTable)
        {
            var resault= await _groupDataAccess.UpdateAsync(lessonTimeTable);
            await _groupDataAccess.SaveChangesAsync();
            return resault;
        }

        public async Task<Lesson> UpdateRemote(Lesson lessonTimeTable)
        {
            return await _apiService.PostAsync<Lesson, Lesson>(DomainData.Domain + "LessonTimeTables/update", lessonTimeTable);
        }
    }
}
