using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if(ModelState.IsValid)
            {
                _studentRepository.AddStudent(student);
               
                return RedirectToAction("StudentEnrollment", "Enrollment", student);
                                
            }
            
            return View(student);
            
        }
    }
}
