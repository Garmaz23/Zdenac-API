namespace Zdenac_API.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }

        public Child Child { get; set; }
        public User User { get; set; }
    }

}
