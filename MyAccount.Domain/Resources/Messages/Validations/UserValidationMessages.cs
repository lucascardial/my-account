using System;
namespace MyAccount.Domain.Resources.Messages.Validations
{
	public static class UserValidationMessages
	{
        public static string NameNullOrEmpty { get; } = "Um Nome de usuário é obrigatório";
        public static string EmailNullOrEmpty { get; } = "O E-mail de usuário é obrigatório";
        public static string PasswordLength { get; } = "A senha deve conter ao menos 8 caracteres";
    }
}

