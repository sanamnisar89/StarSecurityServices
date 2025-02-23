using Microsoft.AspNetCore.Identity;
using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.BussinessLayer
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(AspNetUsers user, string password);

        Task<bool> CreateEmployeeAsync(Employee employee);

        Task<bool> IsEmailExist(string email);

        Task<ProfileVM> GetEmployeeViewModelAsync(string employeeId);
    }
}
