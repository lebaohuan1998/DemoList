using System.ComponentModel.DataAnnotations.Schema;

namespace DemoList.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }  
    }
}
