namespace quandomeutimejoga_server.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Initials { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public IList<CompetitionTeam> CompetitionTeams { get; set; }
    }
}
