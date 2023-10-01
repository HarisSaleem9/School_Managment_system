using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.DTOs;
using SchoolSystemAPI.Repository;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var data = await _repository.GetAllStudentAsync();
            if (data == null)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpGet("GetStudentAddressById")]
        public async Task<IActionResult> GetAllStudents(int id)
        {
            var data = await _repository.GetStudentAddressAsync(id);
            if (data == null)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpPost("ADDStudent")]
        public async Task<IActionResult> AddStudent(StudentDTO student)
        {
            var newStudent = await _repository.AddStudentAsync(student);
            if (newStudent != null)
            {
                return Ok(newStudent);
            }
            return BadRequest();
        }

        [HttpPost("ADDStudentWithCourse")]
        public async Task<IActionResult> AddStudentCourse(StudentsCourseDTO student)
        {
            var newStudent = await _repository.AddStudentCourseAsync(student);
            if (newStudent != null)
            {
                return Ok(newStudent);
            }
            return BadRequest();
        }

        [HttpPut("UpdateStudentbyID")]
        public async Task<IActionResult> UpdateStudentByID(UpdateStudentDTO req)
        {
            var data = await _repository.UpdateStudentbyIdAsync(req);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete("DeleteStudent/{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            string result = await _repository.DeleteStudentAsync(id);
            if (result == "Record Deleted")
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetStudentbyId/{id:int}")]
        public async Task<IActionResult> GetStudentbyId([FromRoute] int id)
        {
            var Student = await _repository.GetStudentByIdAsync(id);
            if (Student != null)
            {
                return Ok(Student);
            }
            return NotFound();
        }
    }
}
