using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DfaCRUDApplication.Models
{
    public class Student
    {
        [Key]
        [DisplayName("Id")]
        [Required]
        public int Sid { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Sname { get; set; }
        [DisplayName("Email")]
        [EmailAddress]
        public string SEmail { get; set; }
        [DisplayName("Gender")]
        [Required]
        public string SGender { get; set; }
        [DisplayName("Date Of Birth")]
        [Required]
        public DateOnly SDob { get; set; }
    }
}
