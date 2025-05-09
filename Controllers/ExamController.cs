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
        public IActionResult AddMarks(int EnrollmentId)
        {
            Console.WriteLine($"Received enrollmentId: {EnrollmentId}");

            var enrollment = _smsDbContext.Enrollments.Include(e => e.Student)
                .FirstOrDefault(e=> e.EnrollmentId == EnrollmentId);


            var viewModel = new ExamResultViewModel
            {
                EnrollmentId = EnrollmentId,
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

                var enrollment = _smsDbContext.Enrollments.Include(e => e.Student)
                .FirstOrDefault(e => e.EnrollmentId == model.EnrollmentId);
               
                return RedirectToAction("StudentDetails", "Student",new {Id = enrollment.StudentId});
            }
            return View(model);
            
        }
    }
}
