using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Career
    {
        [Key]
        public int Id { get; set; }  

        public int EmployeeId { get; set; }  

        public string JobTitle { get; set; }  

        public string CompanyName { get; set; }  

        public string Department { get; set; }  

        public DateTime StartDate { get; set; }  

        public DateTime? EndDate { get; set; } 

        public string JobDescription { get; set; }

        public bool IsActive { get; set; }

        public Employee Employee { get; set; }

    }
}
