using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.BussinessLayer
{
    public interface ICareerRepository
    {
        Task<IEnumerable<CareerVM>> GetAllCareersAsync();
        Task<CareerVM> GetCareerByIdAsync(int careerId);
        Task CreateCareerAsync(CareerVM career);
        Task<bool> UpdateCareerAsync(CareerVM careerVM, int id);
        Task DeleteCareerAsync(int careerId);
    }
}
