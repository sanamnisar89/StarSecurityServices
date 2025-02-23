using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Data;
using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.BussinessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly SignInManager<AspNetUsers> _signManager;

        private readonly AuthContext _context;


        public UserRepository(UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signManager, AuthContext context)
        {

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
            if (checkEmail != null)
            {
                return true;

            }

            return false;
        }

        public async Task<ProfileVM> GetEmployeeViewModelAsync(string employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.AspNetUsers)  // Include AspNetUsers if needed (e.g., for Role)
                .FirstOrDefaultAsync(e => e.AspNetUsersId == employeeId);

            if (employee == null)
            {
                return null; // Employee not found
            }

            var viewModel = new ProfileVM
            {
                Name = employee.Name,
                Role = "",//employee.AspNetUsers?.Role, 
                Address = employee.Address,
                ContactNo = employee.ContactNumber,
                EducationQualification = employee.EducationalQualification,
                EmployeeCode = employee.EmployeeCode,
                Department = "",
                Grade = "",// employee.AspNetUsers?.Grade, // Assuming AspNetUsers has a Grade field
                Client = null //GetClientList(employee.Id) // Example method to get client list related to employee
            };

            return viewModel;
        }
    }
}
