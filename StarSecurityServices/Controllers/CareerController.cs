using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.BussinessLayer;
using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.Controllers
{
    [Route("career")]
    public class CareerController : Controller
    {
        private readonly ICareerRepository _careerRepository;

        public CareerController(ICareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }
        
        
        [HttpGet("careers")]
        public async Task<IActionResult> Careers()
        {
            var careers = await _careerRepository.GetAllCareersAsync();
            return View(careers);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetCareerById(int id)
        {
            var career = await _careerRepository.GetCareerByIdAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        [HttpGet("createCareer")]
        public async Task<IActionResult> CreateCareer()
        {

            return View();
        
        }


        [HttpPost("CreateCareer")]
        public async Task<IActionResult> CreateCareer(CareerVM careerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _careerRepository.CreateCareerAsync(careerViewModel);
                TempData["SuccessMessage"] = "Your contact request has been successfully submitted!";
                RedirectToAction("Careers");


            }
            catch (Exception ex) {

                TempData["ErrorMessage"] = "An error occurred while submitting your request. Please try again later.";

            }

            return RedirectToAction("Careers");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCareer(int id, [FromBody] CareerVM careerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
               var res =  await _careerRepository.UpdateCareerAsync(careerViewModel, id);
               if(res){
                    
                    TempData["SuccessMessage"] = "Your contact request has been successfully submitted!";
                    RedirectToAction("");

               }

            }
            catch (Exception ex) {

                TempData["ErrorMessage"] = "An error occurred while submitting your request. Please try again later.";

            }

            return View();
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(int id)
        {
            await _careerRepository.DeleteCareerAsync(id);
            return NoContent();
        }
    }

}

