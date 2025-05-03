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
                var stdInfo = _studentRepository.AddStudent(student);
                Console.WriteLine($"student id directly from passed objec {student.StudentId}");
                Console.WriteLine($"Student ID saved: {stdInfo.StudentId + stdInfo.Name}");

                return RedirectToAction("StudentEnrollment", "Enrollment", stdInfo);
                                
            }
            
            return View(student);
            
        }
    }
}
