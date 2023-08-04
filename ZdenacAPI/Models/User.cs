using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        
        
        
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [StringLength(13)]
        public string Pin { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Phone]
        public string Mobile { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [StringLength(200)]
        public string UserNote { get; set; }

        public string Photo { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }
    }
 

}
