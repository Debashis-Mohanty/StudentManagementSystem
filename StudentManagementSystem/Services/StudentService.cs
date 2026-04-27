using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Student>> GetAll() =>
            await _repo.GetAll();

        public async Task Add(StudentDto dto)
        {
            await _repo.Add(new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course
            });
        }

        public async Task Update(int id, StudentDto dto)
        {
            var s = await _repo.GetById(id);
            if (s == null) throw new Exception("Not found");

            s.Name = dto.Name;
            s.Email = dto.Email;
            s.Age = dto.Age;
            s.Course = dto.Course;

            await _repo.Update(s);
        }
        public async Task<Student> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task Delete(int id) =>
            await _repo.Delete(id);
    }
}
