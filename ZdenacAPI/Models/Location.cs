namespace Zdenac_API.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
    }


}
