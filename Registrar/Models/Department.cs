using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
  }
}