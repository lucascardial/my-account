namespace MyAccount.Domain.Resources.Messages.Validations
{
	public static class SocialAccountValidationMessages
	{
        public static string SocialIdNullOrEmpty { get; } = "O Social Id é obrigatório";
        public static string TokenNullOrEmpty { get; } = "O Token é obrigatório";
    }
}

