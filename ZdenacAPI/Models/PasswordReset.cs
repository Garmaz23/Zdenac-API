using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class PasswordReset
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ResetToken { get; set; }
        public DateTime ResetDate { get; set; }

        public User User { get; set; }
    }

}
