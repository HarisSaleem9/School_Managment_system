using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;
using SchoolSystemAPI.Repository;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculamController : ControllerBase
    {
        private readonly ICurriculamRepository _curriculamRepository;

        public CurriculamController(ICurriculamRepository curriculamRepository)
        {
            _curriculamRepository = curriculamRepository;
        }

        [HttpPost("AddStandard")]
        public async Task<IActionResult> AddStandard(StandardDTO standard)
        {
            var newStandard = await _curriculamRepository.AddStandardAsync(standard);
            if(newStandard != null)
            {
                return Ok(newStandard);
            }
            return BadRequest();
        }
        [HttpPost("AddCourses")]
        public async Task<IActionResult> AddCourse([FromBody]string name)
        {
            var newCourse = await _curriculamRepository.AddCoursesAsync(name);
            if(newCourse != null)
            {
                return Ok(newCourse);
            }
            return BadRequest();
        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _curriculamRepository.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("GetAllStandards")]
        public async Task<IActionResult> GetStandards()
        {
            var standards = await _curriculamRepository.GetAllStandardsAsync();
            return Ok(standards);
        }

        [HttpPost("GetStandardByIdTandS/{id:int}")]
        public async Task<IActionResult> GetStandardbyIdTandS([FromRoute] int id)
        {
            var standard = await _curriculamRepository.GetStandardByIdWithTandS(id);
            if(standard != null)
            {
                return Ok(standard);
            }
            return NotFound();
            
        }
        [HttpPost("GetCourseByid/{id:int}")]
        public async Task<IActionResult> GetCourseById([FromRoute] int id)
        {
            var course = await _curriculamRepository.GetCourseByIDAsyncs(id);
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound();
        }
        [HttpPut("UpdateCourseByid/{id:int}")]
        public async Task<IActionResult> UpdateCourseById([FromRoute] int id, [FromBody] string name)
        {
            var course = await _curriculamRepository.UpdateCoursebyIdAsync(id,name);
            if (course != null)
            {
                return Ok(course);
            }
            return BadRequest();
        }
        
        [HttpDelete("DeleteCourseByid/{id:int}")]
        public async Task<IActionResult> DeleteCourseById([FromRoute] int id)
        {
            var course = await _curriculamRepository.DeleteCoursebyIdAsync(id);
            if (course != null)
            {
                return Ok("Record Deleted");
            }
            return BadRequest();
        }

        [HttpPost("GetStandardById/{id:int}")]
        public async Task<IActionResult> GetStandardById([FromRoute] int id)
        {
            var standard = await _curriculamRepository.GetStandardByIDAsync(id);
            if (standard != null)
            {
                return Ok(standard);
            }
            return BadRequest();
        }

        [HttpPut("UpdateStandardById")]
        public async Task<IActionResult> UpdateStandardById(UpdateStandardDTO req)
        {
            var standard = await _curriculamRepository.UpdateStandardbyIdAsync(req);
            if (standard != null)
            {
                return Ok(standard);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteStandardById/{id:int}")]
        public async Task<IActionResult> DeleteStandardById([FromRoute]int id)
        {
            var standard = await _curriculamRepository.DeleteStandardbyIdAsync(id);
            if (standard != null)
            {
                return Ok("Record Deleted");
            }
            return BadRequest();
        }
        
    }
}
