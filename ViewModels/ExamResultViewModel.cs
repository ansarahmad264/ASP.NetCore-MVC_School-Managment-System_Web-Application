using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.ViewModels
{
    public class ExamResultViewModel
    {
        public int EnrollmentId { get; set; }
        public string Term { get; set; }

        public List<SubjectMarkViewModel> SubjectMarks { get; set; }
        [ValidateNever]
        public Enrollment Enrollment { get; set; }
    }
}
