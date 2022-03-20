namespace quandomeutimejoga_server.Models
{
    public class CompetitionTeam
    {
        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public Guid TeamId  { get; set; }
        public Team Team { get; set; }
    }
}
