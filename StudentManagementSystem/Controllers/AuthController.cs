using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Helpers;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthController(AppDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            //Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("Admin@123"));
            var user = _context.Users.FirstOrDefault(x => x.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized();

            var token = _jwt.GenerateToken(user.Username);
            return Ok(new { token });
        }
    }
}
