using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Models;

public partial class Student
{
    [DisplayName("Roll")]
    [Required]
    public int Roll { get; set; }
    [DisplayName("Name")]
    [Required]
    public string? Name { get; set; }
    [DisplayName("Gender")]
    [Required]
    public string? Gender { get; set; }
    [DisplayName("Email")]
    [EmailAddress]
    public string? Email { get; set; }
    [DisplayName("Date Of Birth")]
    [Required]
    public DateOnly? Dob { get; set; }
}
