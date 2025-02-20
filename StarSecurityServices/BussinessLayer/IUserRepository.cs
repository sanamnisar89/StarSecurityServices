using Microsoft.AspNetCore.Identity;
using StarSecurityServices.Models;

namespace StarSecurityServices.BussinessLayer
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(AspNetUsers user, string password);

        Task<bool> CreateEmployeeAsync(Employee employee);

        Task<bool> IsEmailExist(string email);
    }
}
