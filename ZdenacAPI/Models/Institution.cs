using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Institution
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
    }
}
