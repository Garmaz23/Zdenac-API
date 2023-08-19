using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Zdenac_API.Models
{
    public class ApiUser : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
 