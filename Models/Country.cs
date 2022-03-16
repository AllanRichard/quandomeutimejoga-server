using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.Models;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CountryCode { get; set; }
    public Continent Continent { get; set; }

    public Country(Guid id, string name, int countryCode, Continent continent)
    {
        Id = id;
        Name = name;
        CountryCode = countryCode;
        Continent = continent;
    }
}
