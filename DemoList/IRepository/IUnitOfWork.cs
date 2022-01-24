using DemoList.Data;

namespace DemoList.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGennericRepository<Course> Courses { get; }
        IGennericRepository<Student> Students { get; }
        Task Save();

    }
}
