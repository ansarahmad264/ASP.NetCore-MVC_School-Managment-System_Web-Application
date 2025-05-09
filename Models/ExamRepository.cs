using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public class ExamRepository : IExamRespository
    {
        private readonly SMSDbContext _context;
        public ExamRepository(SMSDbContext context)
        {
            _context = context;
        }
        public void AddResult(ExamResultViewModel viewModel)
        {
            var examResult = new ExamResult
            {
                EnrollmentId = viewModel.EnrollmentId,
                Term = viewModel.Term
            };

            _context.ExamResults.Add(examResult);

            foreach(var subjectMarks in  viewModel.SubjectMarks)
            {
                var newsubjectMarks = new SubjectMark
                {
                    ExamResultId = examResult.ExamResultId,
                    SubjectName = subjectMarks.SubjectName,
                    ObtainedMarks = subjectMarks.ObtainedMarks,
                    TotalMarks = subjectMarks.TotalMarks
                };
                _context.subjectMarks.Add(newsubjectMarks);
            }

            _context.SaveChanges();

        }
    }
}
