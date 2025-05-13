namespace SchoolManagmentSystem.Models
{
    public interface IFeeRepository
    {
        public List<FeeSchedule> LoadFeeSchedules(int EnrollmentId);
        public void AddFee(int feeScheduleId, string receiptNumber);
        public FeeSchedule GetFeeScheduleById(int feeScheduleId);
    }
}
