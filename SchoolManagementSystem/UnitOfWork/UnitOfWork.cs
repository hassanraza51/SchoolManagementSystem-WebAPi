using SchoolManagementSystem.Data;
using SchoolManagementSystem.Repositories.Classes;
using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public IGuardianRepository Guardians { get; private set; }
        public ISchoolRepository School { get; private set; }
        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Students=new StudentRepository(_context,_logger);
            Teachers=new TeacherRepository(_context,_logger);
            Guardians=new GuardianRepository(_context,_logger);
            School=new SchoolRepository(_context,_logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
