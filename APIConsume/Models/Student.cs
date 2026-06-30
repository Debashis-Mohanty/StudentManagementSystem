using System.ComponentModel;

namespace APIConsume.Models
{
    public class Student
    {
        [DisplayName("Id")]
        public int StuId { get; set; }
        [DisplayName("Name")]
        public string? StuName { get; set; }
        [DisplayName("Gender")]
        public string? StuGender { get; set; }
        [DisplayName("Email")]
        public string? StuEmail { get; set; }
    }
}
