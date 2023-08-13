using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace Zdenac_API.Models.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to 15 characters")]
        public string Password { get; set; }
    }
    public class UserDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

      
    }
}
