using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Models;
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

        [HttpPost]
        public IActionResult ViewFeeRecord(int feeScheduleID, string receiptNumber)
        {
            try
            {
                _feeRepository.AddFee(feeScheduleID, receiptNumber);
                TempData["Success"] = "Payment Recorded Successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            var fee = _feeRepository.GetFeeScheduleById(feeScheduleID);
            return RedirectToAction("ViewFeeRecord", "Fee", new { EnrollmentID = fee.EnrollmentId });
        }
    }
}
