using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DfapproachContext context;
        public StudentController(DfapproachContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await context.Students.ToListAsync();
            return students;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int? id)
        {
            Student student = await context.Students.FirstOrDefaultAsync(x => x.Sid == id);
            if (student != null)
            {
                return student;
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student stu)
        {
            if (stu != null)
            {
                context.Students.Add(stu);
                await context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Edit(int id,Student stu)
        {
            if (id == stu.Sid)
            {
                context.Students.Update(stu);
                await context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            if (id != null)
            {
                Student stu = await context.Students.FirstOrDefaultAsync(x => x.Sid == id);
                if (stu != null)
                {
                    context.Students.Remove(stu);
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
