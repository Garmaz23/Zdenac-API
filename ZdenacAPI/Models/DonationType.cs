using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class DonationType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int Amount { get; set; }
    }
}
