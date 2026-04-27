using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto dto)
        {
            await _service.Add(dto);
            return Ok("Added");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDto dto)
        {
            try
            {
                await _service.Update(id, dto);
                return Ok("Student updated successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetById(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok("Deleted");

        }
    }
}
