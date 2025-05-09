using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class SubjectMark
{
    public int SubjectMarkId { get; set; }
    public int ExamResultId { get; set; }

    public string SubjectName { get; set; }
    public int ObtainedMarks { get; set; }
    public int TotalMarks { get; set; }

    [ValidateNever]
    public ExamResult ExamResult { get; set; }
}
