using Microsoft.AspNetCore.Http.HttpResults;
using SchoolManagmentSystem.ViewModels;

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

        public FeeSchedule AddFee(FeeViewModel model)
        {
            using var transaction = _smsDbContext.Database.BeginTransaction();

            try
            {
                var fee = _smsDbContext.FeeSchedule
                    .FirstOrDefault(f => f.FeeScheduleId == model.FeeScheduleId);

                if (fee == null || fee.IsPaid)
                    throw new Exception("Invalid fee schedule or already paid.");

                fee.IsPaid = true;
                fee.PaidDate = model.PaymentDate;
                fee.ReceiptNumber = model.ReceiptNumber;

                _smsDbContext.SaveChanges();

                var feePayment = new FeePayment
                {
                    FeeScheduleId = model.FeeScheduleId,
                    PaidAmount = model.PaidAmount,
                    PaymentDate = model.PaymentDate,
                    Method = model.Method,
                    Notes = model.Notes
                };

                _smsDbContext.FeePayments.Add(feePayment);
                _smsDbContext.SaveChanges();

                transaction.Commit();
                return fee; // return the updated fee schedule
            }
            catch
            {
                transaction.Rollback();
                throw; // bubble up to the controller
            }

        }

        public FeeSchedule GetFeeScheduleById(int feeScheduleId)
        {
            return _smsDbContext.FeeSchedule
                .FirstOrDefault(f => f.FeeScheduleId == feeScheduleId);
        }
    }
}
