using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;

namespace MyAccount.Domain.Entities
{
	public class SocialAccount : Entity
	{
		public Guid UserId { get; private set; }
		public Guid SocialProviderId { get; private set; }
		public string SocialId { get; private set; }
		public string Token { get; private set; }

        public SocialAccount(Guid userId, Guid socialProviderId, string socialId, string token)
        {
            Validate(socialId, token);

            UserId = userId;
            SocialProviderId = socialProviderId;
            SocialId = socialId;
            Token = token;
        }

        private void Validate(string socialId, string token)
        {
            DomainValidationException.ValidateAll(new List<(bool condition, string errorMessage)>
            {
                (string.IsNullOrEmpty(socialId), SocialAccountValidationMessages.SocialIdNullOrEmpty),
                (string.IsNullOrEmpty(token), SocialAccountValidationMessages.TokenNullOrEmpty),
            });
        }
    }
}

