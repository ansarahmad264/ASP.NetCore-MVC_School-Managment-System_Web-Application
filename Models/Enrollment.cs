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

        // Navigation
        public Student Student { get; set; }
    }

}
