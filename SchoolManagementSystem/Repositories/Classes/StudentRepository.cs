using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.Repositories.Classes
{
    public class StudentRepository:GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context,ILogger logger):base(context, logger)
        {

        }
        public override async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} GetAll method error",typeof(StudentRepository));
                return new List<Student>();
            }
        }
        public override async Task<bool> Update(Student entity)
        {
            try
            {
                var existingStudent=await dbSet.Where(x=>x.ID==entity.ID).FirstOrDefaultAsync();
                if(existingStudent==null)
                    return await Add(entity);

                existingStudent.StudentId = entity.StudentId;
                existingStudent.Image = entity.Image;
                existingStudent.FirstName=entity.FirstName;
                existingStudent.LastName=entity.LastName;
                existingStudent.Gender=entity.Gender;
                existingStudent.DOB = entity.DOB;
                existingStudent.CNIC = entity.CNIC;
                existingStudent.ContactNumber = entity.ContactNumber;
                existingStudent.Address = entity.Address;
                existingStudent.Email = entity.Email;
                existingStudent.DateOfAdmission = entity.DateOfAdmission;
                existingStudent.Class=entity.Class;
                existingStudent.Section=entity.Section;
                existingStudent.Guardian=entity.Guardian;

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Upert Method Error",typeof (StudentRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist=await dbSet.Where(x=>x.ID == id).FirstOrDefaultAsync();
                if(exist!=null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Delete Method Error",typeof(StudentRepository));
                return false;
            }
        }
    }
}
