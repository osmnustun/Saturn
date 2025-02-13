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
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
             await _studentService.Add(student);
            return Ok();
        }
        [HttpPost("remove")]
        public async Task<IActionResult> Remove([FromBody] Student student)
        {
            await _studentService.Delete(student);
            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            await _studentService.Update(student);
            return Ok();
        }
    }
}
