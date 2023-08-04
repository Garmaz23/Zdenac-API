using System.ComponentModel.DataAnnotations;

namespace Zdenac_API.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int DonationTypeId { get; set; }
        public DonationType DonationType { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int SponsorId { get; set; }
        public User Sponsor { get; set; }
        public int Amount { get; set; }
        public DateTime DonationDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }
}
