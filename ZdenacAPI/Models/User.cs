using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Consider not exposing this directly
        public string Pin { get; set; }
        public int RoleId { get; set; }
        public string PhoneNumber { get; set; }
        public int LocationId { get; set; }
        public int GenderId { get; set; }
        public string UserNote { get; set; }
        public string Photo { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }

        public Role Role { get; set; }
        public Location Location { get; set; }
        public Gender Gender { get; set; }
    }




}
