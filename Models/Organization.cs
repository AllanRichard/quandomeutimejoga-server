namespace quandomeutimejoga_server.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }


        public IList<Competition> Competitions { get; set; } = new List<Competition>();
    }
}
