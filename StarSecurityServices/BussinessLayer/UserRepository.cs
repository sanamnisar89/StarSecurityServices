using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Data;
using StarSecurityServices.Models;

namespace StarSecurityServices.BussinessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signManager;

        private readonly AuthContext _context;


        public UserRepository(UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signManager, AuthContext context) {

            _signManager = signManager;
            _userManager = userManager;
            _context = context;
        
        }

        public async Task<IdentityResult> RegisterUserAsync(AspNetUsers user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // Assign a role (e.g., "User") to the new user
                await _userManager.AddToRoleAsync(user, "User");

                // Sign in the user
                await _signManager.SignInAsync(user, isPersistent: false);
            }
            
            return result;
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            var result = await _context.SaveChangesAsync();


            return true;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var checkEmail = await _userManager.FindByEmailAsync(email);
            if (checkEmail != null) { 
                    return true;
            
            }

                return false;
        }
    }
}
