using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTOs;
using SchoolSystemAPI.Repository;

namespace SchoolSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;

        public TeacherController(ITeacherRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeachers()
        {
            return Ok(await _repository.GetAllTeacherAsync());
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody]TeacherDTO teacher)
        {
            var data = await _repository.AddTeacherAsync(teacher);
            if(data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherDTO req)
        {
            var result = await _repository.UpdateTeacherAsync(req);
            return Ok(result);
        }


        [HttpDelete("RemoveTeacher/{id:int}")]
        public async Task<IActionResult> GetAllTeachers([FromRoute] int id)
        {
            var result = await _repository.DeleteTeacherByIDAsync(id);
            if(result == "Recod Deleted")
            {
                return Ok("Recod Deleted");
            }
            return BadRequest();
        }
        

    }
}
