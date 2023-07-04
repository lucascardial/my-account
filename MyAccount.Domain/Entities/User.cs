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

        public User(Guid? guid, string name, string email, string? password, PhoneNumber? phoneNumber)
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
                ( condition: string.IsNullOrEmpty(name),
                    errorMessage: "Um Nome de usuário é obrigatório"),

                ( condition: string.IsNullOrEmpty(email),
                    errorMessage: "O E-mail de usuário é obrigatório"),

                ( condition: !string.IsNullOrEmpty(password) && password.Length < 8,
                    errorMessage: "A senha deve conter ao menos 8 caractéres"),
            });
        }
    }
}

