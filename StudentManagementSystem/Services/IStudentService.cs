using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task Add(StudentDto dto);
        Task Update(int id, StudentDto dto);
        Task<Student> GetById(int id);
        Task Delete(int id);
    }
}
