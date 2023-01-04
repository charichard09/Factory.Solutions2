using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Registrar.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    [Required(ErrorMessage = "Please enter a course name.")]
    public string Name { get; set; }
    // public int DepartmentId { get; set; }
    // public Department Department { get; set; }
    public List<CourseStudent> JoinEntities { get; }
  }
}