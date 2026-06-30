using Microsoft.EntityFrameworkCore;

namespace DfaCRUDApplication.Models
{
    public class StudentInfoContext:DbContext
    {
        public StudentInfoContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
