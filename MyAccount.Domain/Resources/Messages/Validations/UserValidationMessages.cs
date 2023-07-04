using System;
namespace MyAccount.Domain.Resources.Messages.Validations
{
	public static class UserValidationMessages
	{
        public static string NameNullOrEmpty { get; } = "Um Nome do usuário é obrigatório";
        public static string EmailNullOrEmpty { get; } = "O E-mail de usuário é obrigatório";
        public static string PasswordToShort { get; } = "A Senha deve conter ao menos 8 caracteres";
        public static string NameTooShort { get; } = "O Nome deve conter no minímo 5 caracteres";
    }
}

