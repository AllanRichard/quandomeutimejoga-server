using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.Models
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Organization Organization { get; set; }
        public Country Country { get; set; }    
        public Continent Continent { get; set; }

        public Competition(Guid id, string name, Organization organization, Country country, Continent continent)
        {
            Id = id;
            Name = name;
            Organization = organization;
            Country = country;
            Continent = continent;
        }
    }
}
