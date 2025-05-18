using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public interface IAuditRepository
    {
        public Task<List<FeePayment>> GetAuditReport(AuditViewModel model);
    }
}
