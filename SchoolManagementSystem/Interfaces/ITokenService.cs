using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
