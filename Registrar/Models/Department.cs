using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "Please enter a department name.")]
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
  }
}