using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required, StringLength(50)]
        public string Class { get; set; }

        [StringLength(50)]
        public string Section { get; set; }

        [Required]
        public EnrollmentStatus Status { get; set; }  // Now using the enum
        
        [ValidateNever]
        public DateTime? EnrollmentDate { get; set; } = DateTime.Now;

        [ValidateNever]
        public Student Student { get; set; }
    }

}
