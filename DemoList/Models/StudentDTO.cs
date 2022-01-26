using System.ComponentModel.DataAnnotations;

namespace DemoList.Models
{
    public class StudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }
        public CourseDTO Course { get; set; }
    }
    public class CreateStudentDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Student Name  is to long")]
        public string? Name { get; set; }
        public int Age { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Student Address  is to long")]
        public string? Address { get; set; }
        public int CourseId { get; set; }
    }
    public class UpdateStudentDTO : CreateStudentDTO
    {
        public int Id { get; set; }
    }
}
