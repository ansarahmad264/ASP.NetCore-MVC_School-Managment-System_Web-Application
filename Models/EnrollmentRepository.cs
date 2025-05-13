using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SMSDbContext _smsDbContext;
        public EnrollmentRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public void AddEnrollmentDetails(EnrollmentViewModel enrollmentviewModel)
        {

            var enrollment = new Enrollment
            {
                StudentId = enrollmentviewModel.StudentId,
                Class = enrollmentviewModel.Class,
                Section = enrollmentviewModel.Section,
                Status = enrollmentviewModel.Status,
                EnrollmentDate = enrollmentviewModel.EnrollmentDate,
            };

            var studentExists = _smsDbContext.Students.Any(s => s.StudentId == enrollment.StudentId);
            if (!studentExists)
                throw new Exception("Student not found. Cannot enroll a non-existent student.");

            _smsDbContext.Enrollments.Add(enrollment);
            _smsDbContext.SaveChanges();

            var enrollmentDate = enrollment.EnrollmentDate.Value; // Or pass it as a param
            int startMonth = enrollmentDate.Month;
            int year = enrollmentDate.Year;

            var feeSchedules = new List<FeeSchedule>();

            for (int month = startMonth; month <= 12; month++)
            {
                feeSchedules.Add(new FeeSchedule
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    Year = year,
                    Month = month,
                    ExpectedAmount = enrollmentviewModel.FeeAmount, // Placeholder — make dynamic later
                    IsPaid = false,
                    PaidDate = null,
                    ReceiptNumber = null
                });
            }

            _smsDbContext.FeeSchedule.AddRange(feeSchedules);
            _smsDbContext.SaveChanges();             
        }
    }
}
