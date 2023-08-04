using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Multimedia
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string MediaType { get; set; }

        [Required]
        public string MediaLink { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
