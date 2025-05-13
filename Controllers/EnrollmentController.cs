using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public IActionResult StudentEnrollment(Student stdInfo)
        {
            ViewBag.StdInfo = stdInfo;
            return View();
        }

        [HttpPost]
        public IActionResult StudentEnrollment(EnrollmentViewModel enrollmentViewModel)
        {
            if(ModelState.IsValid)
            {
                _enrollmentRepository.AddEnrollmentDetails(enrollmentViewModel);

            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
