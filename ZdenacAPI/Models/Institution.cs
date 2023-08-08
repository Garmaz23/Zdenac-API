using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int GuardianId { get; set; }

        public User Guardian { get; set; }
    }

}
