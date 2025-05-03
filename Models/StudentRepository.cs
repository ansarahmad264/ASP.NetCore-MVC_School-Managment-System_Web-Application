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
    }
}
