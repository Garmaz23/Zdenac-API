using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleNote { get; set; }
    }

}
