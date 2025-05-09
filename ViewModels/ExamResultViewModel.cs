using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.ViewModels
{
    public class ExamResultViewModel
    {
        public int EnrollmentId { get; set; }
        public string Term { get; set; }

        public List<SubjectMarkViewModel> SubjectMarks { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
