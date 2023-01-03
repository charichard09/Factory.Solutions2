
using System.Collections.Generic;
using System;

namespace Registrar.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public List<CourseStudent> JoinEntities { get; set; }
  }
}