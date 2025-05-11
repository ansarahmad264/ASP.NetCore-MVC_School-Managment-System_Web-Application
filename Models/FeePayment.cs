using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Models
{
    //For Audit/ Transactional Logs
    public class FeePayment
    {
        [Key]
        public int FeePaymentId { get; set; }

        [Required]
        public int FeeScheduleId { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public string Method { get; set; }  // optional

        public string Notes { get; set; }

        // Navigation
        public FeeSchedule FeeSchedule { get; set; }
    }

}
