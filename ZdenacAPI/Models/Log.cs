using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public int UserId { get; set; }
        public DateTime ActionDate { get; set; }

        public User User { get; set; }
    }

}
