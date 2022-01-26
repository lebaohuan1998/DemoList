using AutoMapper;
using DemoList.IRepository;
using DemoList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, ILogger<CourseController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var courses = await _unitOfWork.Courses.GetAll(null,null, new List<string> { "Students" });
                var results = _mapper.Map<IList<CourseDTO>>(courses);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetCourses)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _unitOfWork.Courses.Get(q => q.Id == id, new List<string> { "Students" });
                var results = _mapper.Map<CourseDTO>(course);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetCourseById)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
    }
}
