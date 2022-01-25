using AutoMapper;
using DemoList.IRepository;
using DemoList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, ILogger<StudentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll(null, null,new List<string> { "Course" });
                var results = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetStudents)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == id, new List<string> { "Course" });
                var results = _mapper.Map<StudentDTO>(student);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetStudentById)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll(q => q.Name == name, null, new List<string> { "Course" });
                var results = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetStudents)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }

    }
}
