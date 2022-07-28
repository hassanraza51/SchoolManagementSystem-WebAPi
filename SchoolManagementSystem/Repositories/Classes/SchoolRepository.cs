using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.Repositories.Classes
{
    public class SchoolRepository:GenericRepository<School>,ISchoolRepository
    {
        public SchoolRepository(ApplicationDbContext context,ILogger logger):base(context, logger)
        {

        }
        public override async Task<IEnumerable<School>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} GetAll method error",typeof(SchoolRepository));
                return new List<School>();
            }
        }
        public override async Task<bool> Update(School entity)
        {
            try
            {
                var existingSchool=await dbSet.Where(x=>x.RegistrationID==entity.RegistrationID).FirstOrDefaultAsync();
                if(existingSchool==null)
                    return await Add(entity);

                existingSchool.Name=entity.Name;
                existingSchool.RegistrationID=entity.RegistrationID;
                existingSchool.PhoneNo=entity.PhoneNo;
                existingSchool.Address = entity.Address;
                existingSchool.Description = entity.Description;

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{0} Upsert method error", typeof(SchoolRepository));
                return false;
            }
        }
    }
}
