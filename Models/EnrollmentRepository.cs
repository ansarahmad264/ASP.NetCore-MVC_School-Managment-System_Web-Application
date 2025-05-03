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
;
        }
    }
}
