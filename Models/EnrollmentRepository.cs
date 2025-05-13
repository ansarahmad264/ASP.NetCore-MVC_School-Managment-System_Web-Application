using Microsoft.EntityFrameworkCore;

namespace SchoolManagmentSystem.Models
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly SMSDbContext _smsDbContext;
        public EnrollmentRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public void AddEnrollmentDetails(Enrollment enrollment)
        {
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
                    ExpectedAmount = 2000, // Placeholder — make dynamic later
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
