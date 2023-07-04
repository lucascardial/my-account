using System;
namespace MyAccount.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        private const string ManyErrorsMessage = "Um ou mais errors ocorreram na validação";

        public List<string> Errors { get; private set; }

        public DomainValidationException(string error, List<string>? errors = null) : base(error)
        {
            Errors = errors ?? new List<string>();
        }

        public static void When(bool validation, string errorMessage)
        {
            if (!validation)
            {
                throw new DomainValidationException(errorMessage);
            }
        }

        public static void ValidateAll(List<(bool condition, string errorMessage)> validations)
        {
            List<string> errors = new List<string>();

            foreach (var validation in validations)
            {
                if (validation.condition)
                {
                    errors.Add(validation.errorMessage);
                }
            }

            if (errors.Count > 0)
            {
                throw new DomainValidationException(ManyErrorsMessage, errors);
            }
        }
    }

}

