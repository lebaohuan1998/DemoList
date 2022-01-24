using DemoList.Data;
using DemoList.IRepository;

namespace DemoList.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGennericRepository<Course> _courses;

        private IGennericRepository<Student> _students;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGennericRepository<Student> Students => _students ??= new GenericRepository<Student>(_context);

        public IGennericRepository<Course> Courses => _courses ??= new GenericRepository<Course>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
