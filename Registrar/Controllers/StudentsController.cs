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
      if (!ModelState.IsValid)
      {
        return View(student);
      }
      else{
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
      }
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

      return RedirectToAction("Details", new {id = student.StudentId, showForm = false});
    }

    public ActionResult Edit(int id, bool changeName, bool changeDate)
    {
      Student thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == id);
      ViewBag.ChangeName = changeName;
      ViewBag.ChangeDate = changeDate;
      return View (thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Students.Update(student);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = student.StudentId});

    }

    public ActionResult Delete(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirm(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(s => s.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DropCourse(int sId, int cId)
    {
      CourseStudent thisJoin = _db.JoinEntities
                                  .FirstOrDefault(join => (join.StudentId == sId && join.CourseId == cId));
      _db.JoinEntities.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = sId, showForm = false});
    }
  }
}
