using System.ComponentModel.DataAnnotations;

namespace StarSecurityServices.Models
{
    public class Network
    {
        public int Id { get; set; }

        public required string Region { get; set; }

        public required string ContactPerson { get; set; }

        public required string ContactNumber { get; set; }

        public required string Address { get; set; }
    }
}
