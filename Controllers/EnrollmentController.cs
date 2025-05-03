using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;

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
        public IActionResult StudentEnrollment(Enrollment enrollInfo)
        {
            if(ModelState.IsValid)
            {
                _enrollmentRepository.AddEnrollmentDetails(enrollInfo);

            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
