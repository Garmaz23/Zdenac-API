using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Child
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public int BirthLocationId { get; set; }
        public Location BirthLocation { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int MaleSiblings { get; set; }
        public int FemaleSiblings { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        [StringLength(50)]
        public string ParentFather { get; set; }

        [StringLength(50)]
        public string ParentMother { get; set; }

        public int GuardianId { get; set; }
        public User Guardian { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}
