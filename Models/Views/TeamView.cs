using quandomeutimejoga_server.Data;

namespace quandomeutimejoga_server.Models.Views
{
    public class TeamView
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Initials { get; set; }
        public Guid CountryId { get; set; }

        public TeamView(string fullName, string shortName, string initials, Guid countryId)
        {
            FullName = fullName;
            ShortName = shortName;
            Initials = initials;
            CountryId = countryId;
        }

        public List<string> Validations()
        {
            List<string> validations = new List<string>();

            if (string.IsNullOrEmpty(FullName))
            {
                validations.Add("Nome do time não pode ser vázio.");
            }
            else if (string.IsNullOrEmpty(FullName) == false && (FullName.Length < 3 || FullName.Length > 150))
            {
                validations.Add("Nome do time deve conter entre 3 até 150 caracteres.");
            }

            if (string.IsNullOrEmpty(ShortName))
            {
                validations.Add("Nome do popular do time não pode ser vázio.");
            }
            else if (string.IsNullOrEmpty(ShortName) == false && (ShortName.Length < 3 || ShortName.Length > 80))
            {
                validations.Add("Nome do popular do time deve conter entre 3 até 80 caracteres.");
            }

            if (string.IsNullOrEmpty(Initials))
            {
                validations.Add("As iniciais do time não pode ser vázio.");
            }
            else if (string.IsNullOrEmpty(Initials) == false && (Initials.Length < 2 || Initials.Length > 10))
            {
                validations.Add("As iniciais do time deve conter entre 2 até 10 caracteres.");
            }

            if (string.IsNullOrEmpty(CountryId.ToString()))
            {
                validations.Add("Informe o ID do país.");
            } else
            {
                using var context = new AppDbContext();
                var countryExists = context.Countries.Any(t => t.Id == CountryId);
                if (countryExists == false)
                {
                    validations.Add("Cadastro do país não foi encontrado.");
                }
                context.Dispose();
            }

            return validations;
        }
    }
}
