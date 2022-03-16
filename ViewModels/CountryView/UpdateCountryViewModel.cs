using Flunt.Notifications;
using Flunt.Validations;
using quandomeutimejoga_server.Models.Enums;

namespace quandomeutimejoga_server.ViewModels.CountryView
{
    public class UpdateCountryViewModel : Notifiable<Notification>
    {
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public Continent Continent { get; set; }

        public UpdateCountryViewModel(string name, int countryCode, Continent continent)
        {
            Name = name;
            CountryCode = countryCode;
            Continent = continent;
        }

        public UpdateCountryViewModel MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Nome do país não pode ser vázio")
                .IsGreaterOrEqualsThan(Name, 3, "Nome do país deve contem 3 ou mais caracteres")
                .IsLowerOrEqualsThan(Name, 150, "Nome do país deve conter no máximo, 150 caracteres")
                .IsNotNull(CountryCode, "Informe o código do país")
                .IsNotNull(Continent, "Informe o continente"));

            return new UpdateCountryViewModel(Name, CountryCode, Continent);
        }
    }
}
