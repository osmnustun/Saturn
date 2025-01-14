using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

namespace Saturn.Core.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await _studentService.GetAll();
            
        }

        [HttpPost("add")]
        public async Task AddStudent([FromBody] Student student)
        {
             await _studentService.Add(student);

        }
    }
}
