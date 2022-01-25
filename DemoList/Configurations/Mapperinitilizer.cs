using AutoMapper;
using DemoList.Data;
using DemoList.Models;

namespace DemoList.Configurations
{
    public class Mapperinitilizer : Profile
    {
        public Mapperinitilizer()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CreateCoureDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
