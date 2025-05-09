using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagmentSystem.Models;

public class ExamResult
{
    public int ExamResultId { get; set; }
    public int EnrollmentId { get; set; }
    public string Term { get; set; }

    [ValidateNever]
    public List<SubjectMark> SubjectMarks { get; set; }
    [ValidateNever]
    public Enrollment Enrollment { get; set; }
}
