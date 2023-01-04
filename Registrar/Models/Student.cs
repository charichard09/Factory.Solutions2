
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    [Required(ErrorMessage = "Student name required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Date required")]
    public DateTime Date { get; set; }
    public List<CourseStudent> JoinEntities { get; set; }
  }
}