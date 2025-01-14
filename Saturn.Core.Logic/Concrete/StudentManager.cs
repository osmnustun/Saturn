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
    public class StudentManager : IStudentService
    {
        readonly IStudentDataAccess _studentDataAccess;
        readonly ApiService _apiService;

        public StudentManager(IStudentDataAccess studentDataAccess, ApiService apiService)
        {
            _studentDataAccess = studentDataAccess;
           _apiService = apiService;
        }

        public async Task Add(Student student)
        {
            await _studentDataAccess.CreateAsync(student);
            await _studentDataAccess.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
           _studentDataAccess.DeleteAsync(student);
            await _studentDataAccess.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll(Func<Student, bool> predicte)
        {
            return await _studentDataAccess.GetAllAsync(predicte);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
           return await _studentDataAccess.GetAllAsync();
        }

        public async Task RemoteAdd(Student student)
        {
            await _apiService.PostAsync<Student,string>(DomainData.Domain+"student/add", student);
        }

        public Task RemoteDelete(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> RemoteGetAll(Func<Student, bool> predicte)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> RemoteGetAll()
        {
            return await _apiService.GetAsync<List<Student>>(DomainData.Domain + "student/getall", null);
        }

        public Task RemoteUpdate(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Student student)
        {
            _studentDataAccess.UpdateAsync(student);
            await _studentDataAccess.SaveChangesAsync();    
        }
    }
}
