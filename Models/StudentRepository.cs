namespace SchoolManagmentSystem.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SMSDbContext _smsDbContext;
        public StudentRepository(SMSDbContext smsDbContext)
        {
            _smsDbContext = smsDbContext;
        }

        public Student AddStudent(Student student)
        {
            _smsDbContext.Students.Add(student);
            _smsDbContext.SaveChanges();

            var stdInfo = _smsDbContext.Students.FirstOrDefault(s => s.CNIC == student.CNIC || 
                s.StudentId == student.StudentId);

            return stdInfo;
        }
    }
}
