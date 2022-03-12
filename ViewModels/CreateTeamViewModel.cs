using Flunt.Notifications;
using Flunt.Validations;
using quandomeutimejoga_server.Models;

namespace quandomeutimejoga_server.ViewModels
{
    public class CreateTeamViewModel : Notifiable<Notification>
    {
        public string fullName { get; set; } 
        public string shortName { get; set; }
        public string initials { get; set; }  

        public Team MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(fullName, "Informe o nome completo do Time")
                .IsGreaterOrEqualsThan(fullName, 3, "O nome completo deve ter no mínimo 3 caracteres")
                .IsLowerOrEqualsThan(fullName, 100, "O nome completo deve ter no máximo 100 caracteres")
                .IsNotNull(shortName,  "Informe o nome curto do Time")
                .IsGreaterOrEqualsThan(shortName, 3, "O nome curto deve ter no mínimo 3 caracteres")
                .IsLowerOrEqualsThan(shortName, 50, "O nome curto deve ter no máximo 50 caracteres")
                .IsNotNull(initials, "Informe as iniciais do Time")
                .IsGreaterOrEqualsThan(shortName, 3, "As iniciais devem ter no mínimo 3 caracteres")
                .IsLowerOrEqualsThan(shortName, 10, "As iniciais devem ter no máximo 10 caracteres"));

            return new Team(Guid.NewGuid(), fullName, shortName, initials);
        }
    }
}
