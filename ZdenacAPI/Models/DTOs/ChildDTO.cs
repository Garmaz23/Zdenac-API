using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models.DTOs
{
    public class ChildDTO
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

        public int GenderId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int MaleSiblings { get; set; }
        public int FemaleSiblings { get; set; }

        [StringLength(50)]
        public string ParentFather { get; set; }

        [StringLength(50)]
        public string ParentMother { get; set; }

        public int GuardianId { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }
    }
}

