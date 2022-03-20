namespace quandomeutimejoga_server.Models.Views
{
    public class CountryView
    {
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public int Continent { get; set; }

        public CountryView(string name, int countryCode, int continent)
        {
            Name = name;
            CountryCode = countryCode;
            Continent = continent;
        }

        public List<string> Validations()
        {
            List<string> validations = new List<string>();

            if (string.IsNullOrEmpty(Name))
            {
                validations.Add("Nome do país não pode ser vázio.");
            } else if (string.IsNullOrEmpty(Name) == false && (Name.Length < 3 || Name.Length > 120))
            {
                validations.Add("Nome do país deve conter entre 3 até 120 caracteres.");
            } 

            if (CountryCode < 0)
            {
                validations.Add("Código do país não pode ser menor que Zero");
            } else if (CountryCode > 9999)
            {
                validations.Add("Código do país não pode ser maior que 9999");
            }

            if (Continent < 1 || Continent > 5)
            {
                validations.Add("Código do Continente inválido.");
            }
            
            return validations;
        }
    }
}
