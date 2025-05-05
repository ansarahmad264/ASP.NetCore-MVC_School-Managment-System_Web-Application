using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public interface IStudentRepository
    {
        public void AddStudent(Student student);
        public List<Student> SearchStudent(SearchStudentViewModel model);
        public Student SearchStudentbyId(int id);

    }
}
