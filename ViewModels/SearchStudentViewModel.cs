using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.ViewModels
{
    public class SearchStudentViewModel
    {
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? CNIC { get; set; }
        public int? StudentId { get; set; }
        public string? Class { get; set; }
        public string? Section { get; set; }
        public EnrollmentStatus? Status { get; set; }
    }
}
