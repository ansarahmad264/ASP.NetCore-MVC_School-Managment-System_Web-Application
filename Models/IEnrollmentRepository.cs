using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public interface IEnrollmentRepository
    {
        public void AddEnrollmentDetails(EnrollmentViewModel enrollmentviewModel);
    }
}
