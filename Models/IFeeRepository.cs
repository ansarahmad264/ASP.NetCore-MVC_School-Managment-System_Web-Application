using SchoolManagmentSystem.ViewModels;

namespace SchoolManagmentSystem.Models
{
    public interface IFeeRepository
    {
        public List<FeeSchedule> LoadFeeSchedules(int EnrollmentId);
        public FeeSchedule AddFee(FeeViewModel model);
        public FeeSchedule GetFeeScheduleById(int feeScheduleId);
    }
}
