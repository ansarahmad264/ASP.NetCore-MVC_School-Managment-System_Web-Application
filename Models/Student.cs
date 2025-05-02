using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string FatherName { get; set; }

        [Required, StringLength(15)]
        public string CNIC { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }  // Or use an enum here too

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        // Navigation
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
