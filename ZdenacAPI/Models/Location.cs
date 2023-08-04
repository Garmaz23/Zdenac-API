namespace Zdenac_API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }

}
