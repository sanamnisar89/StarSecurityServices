using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.ViewModels
{
    public class CareerVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "This feild is required")]
        public string JobDescription { get; set; }
        
    }
}
