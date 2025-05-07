using SchoolManagmentSystem.Models;

public class ExamResult
{
    public int ExamResultId { get; set; }
    public int EnrollmentId { get; set; }
    public string Term { get; set; }

    public List<SubjectMark> SubjectMarks { get; set; }
    public Enrollment Enrollment { get; set; }
}
