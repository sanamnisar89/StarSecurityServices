using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Careers
    {
        [Key]
        public int Id { get; set; }  
        
        public string JobTitle { get; set; }  
        
        public string Description { get; set; }  
        
        public string Requirements { get; set; }  
        
        public string Location { get; set; }  
        
        public DateTime PostedDate { get; set; }  
        
        public DateTime? ClosingDate { get; set; }  
        
        public bool IsActive { get; set; }  
    }

}
