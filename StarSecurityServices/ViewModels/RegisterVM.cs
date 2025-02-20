using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Enter full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter contact number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Enter qualification")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter confirm password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
