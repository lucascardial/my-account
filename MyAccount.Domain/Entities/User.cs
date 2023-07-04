using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;
using MyAccount.Domain.ValueObjects;

namespace MyAccount.Domain.Entities
{
	public class User
	{

        public Guid Guid { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string? Password { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }

        public User(Guid? guid, string name, string email, string? password = null, PhoneNumber? phoneNumber = null)
        {
            Validate(name, email, password);

            Guid = guid ?? Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        private static void Validate(string name, string email, string? password)
        {
            DomainValidationException.ValidateAll(new List<(bool condition, string errorMessage)>
            {
                (string.IsNullOrEmpty(name), UserValidationMessages.NameNullOrEmpty),

                (!string.IsNullOrEmpty(name) && name.Length < 5, UserValidationMessages.NameTooShort),

                (string.IsNullOrEmpty(email), UserValidationMessages.EmailNullOrEmpty),

                (!string.IsNullOrEmpty(password) && password.Length < 8,
                   UserValidationMessages.PasswordToShort)
            });
        }
    }
}

