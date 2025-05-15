using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;
using SchoolManagmentSystem.ViewModels;
namespace SchoolManagmentSystem.Controllers
{
    public class FeeController : Controller
    {
        private readonly SMSDbContext _smsDbContext;
        private readonly IFeeRepository _feeRepository;
        public FeeController (SMSDbContext SmsDbContext, IFeeRepository feeRepository)
        {
            _smsDbContext = SmsDbContext;
            _feeRepository = feeRepository;
        }
        public IActionResult ViewFeeRecord(int EnrollmentID)
        {
            var FeeScheduleRecord = _feeRepository.LoadFeeSchedules(EnrollmentID); 
            return View(FeeScheduleRecord);
        }

      
        [HttpGet]
        public IActionResult FeePayment(int id)
        {
            Console.WriteLine("FeePayment GET called");
            var model = new FeeViewModel
            {
                FeeScheduleId = id,
                PaymentDate = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FeePayment(FeeViewModel model)
        {
            Console.WriteLine("FeePayment called" + model.FeeScheduleId);
            try
            {
                if (ModelState.IsValid)
                {                     
                    var fee = _feeRepository.AddFee(model);
                    TempData["Success"] = "Payment Recorded Successfully!";

                    return RedirectToAction("ViewFeeRecord", new { EnrollmentID = fee.EnrollmentId });
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            Console.WriteLine("ModelState is not valid");
            return View(model);
        }
    }
}
