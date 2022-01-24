namespace DemoList.Data
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
        public string? Class { get; set; }
        public virtual IList<Student> Students { get; set; }
    }
}
