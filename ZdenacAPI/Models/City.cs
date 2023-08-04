using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string PostNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }
    }
}
