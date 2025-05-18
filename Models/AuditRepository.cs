using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public class AuditRepository : IAuditRepository
    {
        private readonly SMSDbContext _smsDbContext;

        public AuditRepository(SMSDbContext context)
        {
            _smsDbContext = context;
        }

        public Task<List<FeePayment>> GetAuditReport(AuditViewModel model)
        {
            var query = _smsDbContext.FeePayments
                .Include(fp => fp.FeeSchedule)
                    .ThenInclude(fs => fs.Enrollment) // Assuming this navigation
                .Where(fp => fp.PaymentDate.Year == model.Year); // Year is required

            if (model.Month.HasValue)
            {
                query = query.Where(fp => fp.PaymentDate.Month == model.Month.Value);
            }

            if (!string.IsNullOrEmpty(model.Class))
            {
                query = query.Where(fp => fp.FeeSchedule.Enrollment.Class == model.Class);
            }

            if (!string.IsNullOrEmpty(model.Section))
            {
                query = query.Where(fp => fp.FeeSchedule.Enrollment.Section == model.Section);
            }

            return query.ToListAsync();
        }

    }

}
