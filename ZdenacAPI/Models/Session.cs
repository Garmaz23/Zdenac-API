namespace Zdenac_API.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool Approved { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
