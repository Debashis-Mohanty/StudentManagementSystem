using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoApi;

public partial class Student
{
    [DisplayName("Id")]
    public int Sid { get; set; }

    [DisplayName("Name")]

    public string Sname { get; set; } = null!;
    [DisplayName("Email")]

    public string Semail { get; set; } = null!;
    [DisplayName("Gender")]

    public string Sgender { get; set; } = null!;
    [DisplayName("Date Of Birth")]

    public DateOnly Sdob { get; set; }
}
