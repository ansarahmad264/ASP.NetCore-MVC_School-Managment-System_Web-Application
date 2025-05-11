using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public interface IExamRespository
    {
        public void AddResult(ExamResultViewModel examResultViewModel);
        public List<ExamResult> GetExamResults(int EnrollmentId);
    }
}
