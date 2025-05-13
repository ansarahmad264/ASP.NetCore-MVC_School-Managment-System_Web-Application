using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagmentSystem.Models;
namespace SchoolManagmentSystem.ViewModels
{
    public class EnrollmentViewModel
    {
                
        [Required]
        public int StudentId { get; set; }

        [Required, StringLength(50)]
        public string Class { get; set; }

        [StringLength(50)]
        public string Section { get; set; }

        [Required]
        public EnrollmentStatus Status { get; set; }  // Now using the enum

        public DateTime? EnrollmentDate { get; set; } = DateTime.Now;

        public Decimal FeeAmount { get; set; }
        
        [ValidateNever]
        public Student Student { get; set; }
    }
}
