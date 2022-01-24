using System.ComponentModel.DataAnnotations;

namespace DemoList.Models
{
    public class CourseDTO : CreateCoureDTO
    {
        public int Id { get; set; }
        public virtual IList<StudentDTO> Students { get; set; }
    }

    public class CreateCoureDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Coure Name  is to long")]
        public string? Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Class Name  is to long")]
        public string? Class { get; set; }
    }
}
