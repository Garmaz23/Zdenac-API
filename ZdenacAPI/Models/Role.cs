using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(200)]
        public string RoleNote { get; set; }
    }
}
