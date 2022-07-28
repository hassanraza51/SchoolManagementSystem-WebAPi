using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGuardianRepository Guardians { get; }
        ISchoolRepository School { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        Task CompleteAsync();
    }
}
