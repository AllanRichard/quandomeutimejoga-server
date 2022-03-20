using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.Models;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int CountryCode { get; set; }
    public Continent Continent { get; set; }

    public IList<Organization> Organizations { get; set; } = new List<Organization>();
    public IList<Competition> Competitions { get; set; } = new List<Competition>();
    public IList<Team> Teams { get; set; } = new List<Team>();
}
