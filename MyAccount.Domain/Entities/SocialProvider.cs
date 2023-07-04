using System;
using MyAccount.Domain.Validation;

namespace MyAccount.Domain.Entities
{
	public class SocialProvider
	{
		public Guid Guid { get; private set; }
		public string Name { get; private set; }
		public bool Enabled { get; private set; }

        public SocialProvider(Guid guid, string name, bool enabled)
		{
			Validate(name);

			Guid = guid;
			Name = name;
			Enabled = enabled;
		}

		private static void Validate(string name)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name),
				"O Nome do provedor social é obrigatório");
		}
	}
}

