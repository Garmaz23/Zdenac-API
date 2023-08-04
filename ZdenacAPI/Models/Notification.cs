using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateSent { get; set; }
    }
}
