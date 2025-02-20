using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.BussinessLayer;
using StarSecurityServices.Models;
using StarSecurityServices.ViewModels;

namespace StarSecurityServices.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isEmailExist = await _userRepository.IsEmailExist(model.Email);

            if (isEmailExist) {

                ModelState.AddModelError(string.Empty, "Email already exist");
                return View(model);


            }

            // Map RegisterModel to ApplicationUser
            var user = new AspNetUsers
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userRepository.RegisterUserAsync(user, model.Password);

            if (result.Succeeded)
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    Address = model.Address,
                    ContactNumber = model.ContactNumber,
                    EducationalQualification = model.Qualification,
                    AspNetUsersId = user.Id

                };


                var result_emp = await _userRepository.CreateEmployeeAsync(employee);


                return Ok(new { message = "User registered successfully." });
            }

            return BadRequest(result.Errors);
        }
    }
}

