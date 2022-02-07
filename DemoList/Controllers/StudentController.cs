using AutoMapper;
using DemoList.Data;
using DemoList.IRepository;
using DemoList.Models;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetStudents([FromQuery] RequestParams requestParams)
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll(null, null,new List<string> { "Course" }, requestParams);
                var results = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetStudents)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [HttpGet("{id:int}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _unitOfWork.Students.Get(q => q.Id == id, new List<string> { "Course" });
            if (student == null)
            {
                throw new Exception();
            }
            var results = _mapper.Map<StudentDTO>(student);
            return Ok(results);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentByName(string name)
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll(q => q.Name.Contains(name), null, new List<string> { "Course" });
                var results = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(GetStudents)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var student = _mapper.Map<Student>(studentDTO);
                await _unitOfWork.Students.Insert(student);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(CreateStudent)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == studentDTO.Id);

                if (student == null)
                {
                    return BadRequest("Submit data is invalidate");
                }
                _mapper.Map(studentDTO,student);
                _unitOfWork.Students.Update(student);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(UpdateStudent)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }
            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == id);

                if (student == null)
                {
                    return BadRequest("Submit data is invalidate");
                }
                await _unitOfWork.Students.Delete(id);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the  {nameof(DeleteStudent)}");
                return StatusCode(500, "Internal Server Error . Please Try again later.");
            }
        }

    }
}
