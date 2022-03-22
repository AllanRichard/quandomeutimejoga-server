using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.Models
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public TypeCompetition TypeCompetition { get; set; }
        public string? Season { get; set; }
        public IList<CompetitionTeam>? CompetitionTeams { get; set; }
        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
