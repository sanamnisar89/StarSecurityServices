using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Data;
using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.BussinessLayer
{
    public class CareerRepository : ICareerRepository
    {
        private readonly AuthContext _context;

        public CareerRepository(AuthContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CareerVM>> GetAllCareersAsync()
        {
            var res = await _context.Career.Include(c => c.Employee).Where(c => c.IsActive == true).ToListAsync();
            var careerViewModels = res.Select(c => new CareerVM
            {
                Id = c.Id,
                JobTitle = c.JobTitle,
                CompanyName = c.CompanyName,
                Department = c.Department,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                JobDescription = c.JobDescription,

            }).ToList();

            return careerViewModels;
        }

        public async Task<CareerVM> GetCareerByIdAsync(int careerId)
        {
            var res = await _context.Career.Include(c => c.Employee)
                                          .FirstOrDefaultAsync(c => c.Id == careerId);

            if (res == null) {

                return null;
            
            
            
            }
            
            var careerViewModel = new CareerVM
            {
                Id = res.Id,
                JobTitle = res.JobTitle,
                CompanyName = res.CompanyName,
                Department = res.Department,
                StartDate = res.StartDate,
                EndDate = res.EndDate,
                JobDescription = res.JobDescription,

            };

            return careerViewModel;

        }

        public async Task CreateCareerAsync(CareerVM careerVM)
        {

            var career = new Career
            {
                JobTitle = careerVM.JobTitle,
                CompanyName = careerVM.CompanyName,
                Department = careerVM.Department,
                StartDate = careerVM.StartDate,
                EndDate = careerVM.EndDate,
                JobDescription = careerVM.JobDescription,
                IsActive = true,
                EmployeeId = 1,
            };

            await _context.Career.AddAsync(career);
            await _context.SaveChangesAsync();

            
        }

        public async Task<bool> UpdateCareerAsync(CareerVM careerVM, int id)
        {
            var career = await _context.Career.Include(c => c.Employee)
                                          .FirstOrDefaultAsync(c => c.Id == id);

            if (career == null)
            {
                return false;

            }

            career.JobTitle = careerVM.JobTitle;
            career.CompanyName = careerVM.CompanyName;
            career.Department = careerVM.Department;
            career.StartDate = careerVM.StartDate;
            career.EndDate = careerVM.EndDate;
            career.JobDescription = careerVM.JobDescription;

            _context.Career.Update(career);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCareerAsync(int careerId)
        {
            var career = await _context.Career.FindAsync(careerId);
            if (career != null)
            {
                _context.Career.Remove(career);
                await _context.SaveChangesAsync();
            }
        }
    }
}
