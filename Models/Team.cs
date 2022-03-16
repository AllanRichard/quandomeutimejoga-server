namespace quandomeutimejoga_server.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Initials { get; set; }

        public Team(Guid id, string fullName, string shortName, string initials)
        {
            Id = id;
            FullName = fullName;
            ShortName = shortName;
            Initials = initials;
        }
    }
}
