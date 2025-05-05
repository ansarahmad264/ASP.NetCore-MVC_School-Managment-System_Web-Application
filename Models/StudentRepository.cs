using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SMSDbContext _smsDbContext;
        public StudentRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public void AddStudent(Student student)
        {
            _smsDbContext.Students.Add(student);
            _smsDbContext.SaveChanges();
        }

        public List<Student> SearchStudent(SearchStudentViewModel model)
        {
            var query = _smsDbContext.Students
                .Include(s => s.Enrollments) // plural!
                .AsQueryable();

            if (!string.IsNullOrEmpty(model.Name))
                query = query.Where(s => s.Name.Contains(model.Name));

            if (!string.IsNullOrEmpty(model.FatherName))
                query = query.Where(s => s.FatherName.Contains(model.FatherName));

            if (!string.IsNullOrEmpty(model.CNIC))
                query = query.Where(s => s.CNIC == model.CNIC);

            if (model.StudentId.HasValue)
                query = query.Where(s => s.StudentId == model.StudentId);

            if (!string.IsNullOrEmpty(model.Class))
                query = query.Where(s =>
                    s.Enrollments.Any(e => e.Class == model.Class));

            if (!string.IsNullOrEmpty(model.Section))
                query = query.Where(s =>
                    s.Enrollments.Any(e => e.Section == model.Section));

            if (model.Status != null)
                query = query.Where(s =>
                    s.Enrollments.Any(e => e.Status == model.Status));

            return query.ToList();
        }

        public Student SearchStudentbyId(int studentId)
        {
            return _smsDbContext.Students.Include(s => s.Enrollments)
                .SingleOrDefault(s => s.StudentId ==  studentId);
                                            
        }

    }


}
