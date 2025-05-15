using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.ViewModels
{
    public class FeeViewModel
    {
        [Required]
        public int FeeScheduleId { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public string? Method { get; set; }
        public string? ReceiptNumber { get; set; }  

        public string? Notes { get; set; }
    }
}
