using System.ComponentModel.DataAnnotations;

namespace StudentCourseRegistration.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course is required.")]
        [StringLength(50, ErrorMessage = "Course name cannot exceed 50 characters.")]
        [Display(Name = "Course / Department")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Semester is required.")]
        [Range(1, 8, ErrorMessage = "Semester must be an integer between 1 and 8.")]
        [Display(Name = "Current Semester")]
        public int? Semester { get; set; }
    }
}
