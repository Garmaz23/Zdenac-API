using System.ComponentModel.DataAnnotations.Schema;

namespace Zdenac_API.Models
{
    public class Parent
    {
        public int Id { get; set; }
        
        public int ChildId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }

        public required Child Child { get; set; }
        public required User User { get; set; }
    }

}
