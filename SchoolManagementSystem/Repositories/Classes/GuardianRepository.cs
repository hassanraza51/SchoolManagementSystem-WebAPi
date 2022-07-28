using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repositories.Interfaces;

namespace SchoolManagementSystem.Repositories.Classes
{
    public class GuardianRepository:GenericRepository<Guardian>,IGuardianRepository
    {
        public GuardianRepository(ApplicationDbContext context,ILogger logger):base(context, logger)
        {

        }
        public override async Task<IEnumerable<Guardian>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} GetAll Method Error",typeof(GuardianRepository));
                return new List<Guardian>();
            }
        }
        public override async Task<bool> Update(Guardian entity)
        {
            try
            {
                var existingParent=await dbSet.Where(x=>x.ID==entity.ID).FirstOrDefaultAsync();
                if(existingParent==null)
                    return await Add(entity);

                existingParent.Image = entity.Image;
                existingParent.FirstName = entity.FirstName;
                existingParent.LastName = entity.LastName;
                existingParent.Gender = entity.Gender;
                existingParent.CNIC = entity.CNIC;
                existingParent.ContactNumber = entity.ContactNumber;
                existingParent.Address = entity.Address;
                existingParent.Email=entity.Email;

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Upsert method error",typeof (GuardianRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist=await dbSet.Where(x=>x.ID==id).FirstOrDefaultAsync();
                if(exist!=null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"{0} Delete method error",typeof(GuardianRepository));
                return false;
            }
        }
    }
}
