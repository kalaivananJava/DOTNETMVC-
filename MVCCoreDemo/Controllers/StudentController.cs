using Microsoft.AspNetCore.Mvc;
using MVCCoreDemo.Models;

namespace MVCCoreDemo.Controllers  
{  
    public class StudentController : Controller  
    {  
        StudentDataAccessLayer objstudent = new StudentDataAccessLayer();  
  
        public IActionResult Index()  
        {  
            List<Student> lststudent = new List<Student>();  
            lststudent = objstudent.GetAllStudent().ToList();  
  
            return View(lststudent);  
        }  
        [HttpGet]  
public IActionResult Create()  
{  
    return View();  
}  
  
[HttpPost]  
[ValidateAntiForgeryToken]  
public IActionResult Create([Bind] Student student)  
{  
    if (ModelState.IsValid)  
    {  
        objstudent.AddStudent(student);  
        return RedirectToAction("Index");  
    }  
    return View(student);  
} 

[HttpGet]  
public IActionResult Details(int? id)  
{  
    if (id == null)  
    {  
        return NotFound();  
    }  
    Student student = objstudent.GetStudentData(id);  
  
    if (student == null)  
    {  
        return NotFound();  
    }  
    return View(student);  
}

[HttpGet]  
public IActionResult Delete(int? id)  
{  
    if (id == null)  
    {  
        return NotFound();  
    }  
    Student student = objstudent.GetStudentData(id);  
  
    if (student == null)  
    {  
        return NotFound();  
    }  
    return View(student);  
}  
  
[HttpPost, ActionName("Delete")]  
[ValidateAntiForgeryToken]  
public IActionResult DeleteConfirmed(int? id)  
{  
    objstudent.DeleteStudent(id);  
    return RedirectToAction("Index");  
}
     }  
     
}
