using MyAccount.Domain.Validation;

namespace MyAccount.Domain.ValueObjects
{
    public sealed class PhoneNumber
    {
        public string CountryCode { get; private set; }
        public string AreaCode { get; private set; }
        public string Number { get; private set; }

        public PhoneNumber(string countryCode, string areaCode, string number)
        {
            CountryCode = countryCode;
            AreaCode = areaCode;
            Number = number;
        }

        private static void Validate(string countryCode, string areaCode, string number)
        {
            DomainValidationException.ValidateAll(new List<(bool condition, string errorMessage)>
            {
                ( condition: string.IsNullOrEmpty(countryCode),
                    errorMessage: "O Código do país do número de telefone é obrigatório"),

                ( condition: string.IsNullOrEmpty(areaCode),
                    errorMessage: "O Código de área do número de telefone é é obrigatório"),

                ( condition: string.IsNullOrEmpty(number),
                    errorMessage: "O Número do telefone é obrigatório"),
            });
        }
    }

}

