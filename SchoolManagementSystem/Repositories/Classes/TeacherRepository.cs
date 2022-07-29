using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.Repositories.Classes
{
    public class TeacherRepository:GenericRepository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context,ILogger logger):base(context, logger)
        {

        }
        public override async Task<IEnumerable<Teacher>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} GetAll method Error",typeof(TeacherRepository));
                return new List<Teacher>();
            }
        }
        public override async Task<bool> Update(Teacher entity)
        {
            try
            {
                var existingTeacher = await dbSet.Where(x => x.ID == entity.ID).FirstOrDefaultAsync();
                if (existingTeacher == null)
                    return await Add(entity);

                existingTeacher.TeacherID = entity.TeacherID;
                existingTeacher.Image = entity.Image;
                existingTeacher.FirstName = entity.FirstName;
                existingTeacher.LastName = entity.LastName;
                existingTeacher.Gender = entity.Gender;
                existingTeacher.CNIC = entity.CNIC;
                existingTeacher.ContactNumber = entity.ContactNumber;
                existingTeacher.Email = entity.Email;
                existingTeacher.Address = entity.Address;
                existingTeacher.Qualification=entity.Qualification;
                existingTeacher.DateOfJoining = entity.DateOfJoining;
                existingTeacher.Salary = entity.Salary;

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Upsert Method Error",typeof (TeacherRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Delete Method Error",typeof(TeacherRepository));
                return false;
            }
        }
    }
}
