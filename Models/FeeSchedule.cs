using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Models
{
    public class FeeSchedule
    {
        [Key]
        public int FeeScheduleId { get; set; }

        [Required]
        public int EnrollmentId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public decimal ExpectedAmount { get; set; }

        public bool IsPaid { get; set; } = false;

        public DateTime? PaidDate { get; set; }

        public string ReceiptNumber { get; set; }

        // Navigation
        public Enrollment Enrollment { get; set; }
    }

}
