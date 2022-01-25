using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoList.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Name = "Course1",
                    Class = "Class1"
                },
                new Course
                {
                    Id = 2,
                    Name = "Course2",
                    Class = "Class2"
                },
                new Course
                {
                    Id = 3,
                    Name = "Course3",
                    Class = "Class3"
                }
                );

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Student1",
                    Age = 1,
                    Address = "address1",
                    CourseId = 1,
                },
                new Student
                {
                    Id = 2,
                    Name = "Student2",
                    Age = 2,
                    Address = "address2",
                    CourseId = 1,
                },
                new Student
                {
                    Id = 3,
                    Name = "Student3",
                    Age = 3,
                    Address = "address3",
                    CourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Student4",
                    Age = 4,
                    Address = "address4",
                    CourseId = 3
                }
                );
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
