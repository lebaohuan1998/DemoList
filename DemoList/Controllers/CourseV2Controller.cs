using AutoMapper;
using DemoList.Data;
using DemoList.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DemoList.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/course")]
    [ApiController]
    public class CourseV2Controller : ControllerBase
    {
        private DatabaseContext _context;

        public CourseV2Controller(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(_context.Courses);
        }
    }
}
