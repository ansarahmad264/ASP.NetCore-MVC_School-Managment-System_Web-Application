using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;
using SchoolManagmentSystem.ViewModels;

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

        [HttpGet]
        public IActionResult SearchStudent()
        {
            return View(new SearchStudentViewModel());
        }
        [HttpPost]
        public IActionResult SearchStudent(SearchStudentViewModel searchStudent)
        {
            if (ModelState.IsValid)
            {
                var searchResult = _studentRepository.SearchStudent(searchStudent);
                return View("SearchResult", searchResult);
            }
            return View(searchStudent);
        }

        public IActionResult StudentDetails(int id)
        {
            var student  = _studentRepository.SearchStudentbyId(id);
            return View("StudentDetails", student);
        }
    }
}
