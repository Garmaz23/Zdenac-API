using Microsoft.AspNetCore.Identity;

namespace Zdenac_API.Models
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
 