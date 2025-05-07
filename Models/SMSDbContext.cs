using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace SchoolManagmentSystem.Models
{
    public class SMSDbContext : IdentityDbContext
    {
        public SMSDbContext(DbContextOptions<SMSDbContext> options) 
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<SubjectMark> subjectMarks { get; set; }
    }
}
