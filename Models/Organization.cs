namespace quandomeutimejoga_server.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

        public Organization(Guid id, string name, Country country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
