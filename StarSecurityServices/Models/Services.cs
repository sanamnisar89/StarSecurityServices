using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Services
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
