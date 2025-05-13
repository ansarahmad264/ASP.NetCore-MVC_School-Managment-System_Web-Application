using Microsoft.AspNetCore.Http.HttpResults;

namespace SchoolManagmentSystem.Models
{
    public class FeeRepository : IFeeRepository
    {
        private readonly SMSDbContext _smsDbContext;
        public FeeRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public List<FeeSchedule> LoadFeeSchedules(int EnrolmentId)
        {
            var feeRecord = _smsDbContext.FeeSchedule.Where(f => f.EnrollmentId == EnrolmentId);
            return feeRecord.ToList();
        }

        public void AddFee(int feeScheduleID, string receiptNumber)
        {
            var fee = _smsDbContext.FeeSchedule
                .FirstOrDefault(f => f.FeeScheduleId == feeScheduleID);

            if(fee == null || fee.IsPaid)
            {
                throw new Exception("Invalid fee schedule or already paid.");
            }
            fee.IsPaid = true;
            fee.PaidDate = DateTime.Now;
            fee.ReceiptNumber = receiptNumber;

            _smsDbContext.SaveChanges();
        }

        public FeeSchedule GetFeeScheduleById(int feeScheduleId)
        {
            return _smsDbContext.FeeSchedule
                .FirstOrDefault(f => f.FeeScheduleId == feeScheduleId);
        }
    }
}
