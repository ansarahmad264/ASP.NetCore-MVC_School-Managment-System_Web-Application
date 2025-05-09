using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Models;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Controllers
{
    public class ExamController : Controller
    {
        private readonly SMSDbContext _smsDbContext;
        private readonly IExamRespository _examRespository;

        public ExamController(SMSDbContext smsDbContext, IExamRespository examRespository)
        {
            _smsDbContext = smsDbContext;
            _examRespository = examRespository;
        }
        [HttpGet]
        public IActionResult AddMarks(int enrollId)
        {
            var enrollment = _smsDbContext.Enrollments.Include(e => e.Student)
                .FirstOrDefault(e=> e.EnrollmentId == enrollId);

            var viewModel = new ExamResultViewModel
            {
                EnrollmentId = enrollId,
                Enrollment = enrollment
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddMarks(ExamResultViewModel model)
        {
            if (ModelState.IsValid)
            {
               _examRespository.AddResult(model);
                TempData["SuccessMessage"] = "Marks saved successfully!";
                return RedirectToAction("StudentDetails", model.Enrollment.StudentId);
            }
            return View(model);
            
        }
    }
}
