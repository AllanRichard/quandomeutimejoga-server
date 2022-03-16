using Flunt.Notifications;
using Flunt.Validations;
using quandomeutimejoga_server.Models;

namespace quandomeutimejoga_server.ViewModels.TeamView
{
    public class CreateTeamViewModel : Notifiable<Notification>
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Initials { get; set; }

        public CreateTeamViewModel(string fullName, string shortName, string initials)
        {
            FullName = fullName;
            ShortName = shortName;
            Initials = initials;
        }

        public Team MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(FullName, "Nome completo do time não pode ser vazio")
                .IsGreaterOrEqualsThan(FullName, 5, "Nome completo do time deve ter 5 ou mais caracteres")
                .IsLowerOrEqualsThan(FullName, 100, "Nome completo do time deve ter 100 caracteres no máximo")
                .IsNotNull(ShortName, "Nome popular do time não pode ser vazio")
                .IsGreaterOrEqualsThan(ShortName, 5, "Nome popular do time deve ter 5 ou mais caracteres")
                .IsLowerOrEqualsThan(ShortName, 50, "Nome popular do time deve ter 50 caracteres no máximo")
                .IsNotNull(Initials, "As Iniciais do time não pode ser vazio")
                .IsGreaterOrEqualsThan(Initials, 3, "As Iniciais do time deve ter 3 ou mais caracteres")
                .IsLowerOrEqualsThan(Initials, 10, "As Iniciais do time deve ter 10 caracteres no máximo"));

            return new Team(Guid.NewGuid(), FullName, ShortName, Initials);
        }
    }
}
