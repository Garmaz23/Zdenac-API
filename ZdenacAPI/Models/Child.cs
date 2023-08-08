using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zdenac_API.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int BirthLocationId { get; set; }
        public int GenderId { get; set; }
        public string Email { get; set; }
        public int MaleSiblings { get; set; }
        public int FemaleSiblings { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public int InstitutionId { get; set; }
        public string Remark { get; set; }

        public Location BirthLocation { get; set; }
        public Gender Gender { get; set; }
        public Institution Institution { get; set; }
    }

}
