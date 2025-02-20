using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }  

        public string Name { get; set; } 
        
        public string Address { get; set; }
        
        public string ContactNumber { get; set; }
        
        public string EducationalQualification { get; set; }
        
        public string? EmployeeCode { get; set; }  

        public string AspNetUsersId { get; set; }

        public AspNetUsers AspNetUsers { get; set; }


    }
}
