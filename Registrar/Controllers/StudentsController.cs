using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly RegistrarContext _db;

    public StudentsController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Student> model = _db.Students.ToList();
      return View(model); //model passed to view is an object type of "List<Student>"
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id, bool showForm)
    { 
      Student thisStudent = _db.Students.Include(student => student.JoinEntities)
                                        .ThenInclude(join => join.Course)
                                        .FirstOrDefault(student => student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name"); 
      ViewBag.showForm = showForm;
      return View(thisStudent);
    }    

    [HttpPost, ActionName("Details")]
    public ActionResult AddCourse(int courseId, Student student)
    {
      #nullable enable
      CourseStudent? joinEntity = _db.JoinEntities.FirstOrDefault(join => (join.StudentId == student.StudentId && join.CourseId == courseId));
      #nullable disable

      if (joinEntity == null && courseId != 0)
      {
        _db.JoinEntities.Add(new CourseStudent() { CourseId = courseId, StudentId = student.StudentId });
        _db.SaveChanges();
      }

      return RedirectToAction("Index");
    }
  }
}
