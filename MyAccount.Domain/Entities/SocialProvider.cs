using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;

namespace MyAccount.Domain.Entities
{
	public class SocialProvider : Entity
	{
		public string Name { get; private set; }
		public bool Enabled { get; private set; }

        public SocialProvider(string name, bool enabled): base()
		{
			Validate(name);

			Name = name;
			Enabled = enabled;
		}

		private void Validate(string name)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name),
                SocialProviderValidationMessages.NameEmptyOrNull);
		}
	}
}

