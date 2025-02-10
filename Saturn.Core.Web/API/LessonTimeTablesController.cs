using Microsoft.AspNetCore.Mvc;
using Saturn.Core.Entity.DatabaseEntities;
using Saturn.Core.Logic.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Saturn.Core.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonTimeTablesController : ControllerBase
    {
        readonly ILessonTimeTableServices _lessonTimeTableServices;

        public LessonTimeTablesController(ILessonTimeTableServices lessonTimeTableServices)
        {
            _lessonTimeTableServices = lessonTimeTableServices;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _lessonTimeTableServices.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Lesson lesson)
        {
            if (lesson == null)
                return NotFound();
            await _lessonTimeTableServices.Add(lesson);
            return Ok();
        }
    }
}
