using System;
using MyAccount.Domain.Validation;

namespace MyAccount.Domain.Entities
{
	public class SocialAccount
	{
		public Guid Guid { get; private set; }
		public Guid UserId { get; private set; }
		public Guid SocialProviderId { get; private set; }
		public string SocialId { get; private set; }
		public string Token { get; private set; }

        public SocialAccount(Guid guid, Guid userId, Guid socialProviderId, string socialId, string token)
        {
            Guid = guid;
            UserId = userId;
            SocialProviderId = socialProviderId;
            SocialId = socialId;
            Token = token;
        }

        private static void Validate(string socialId, string token)
        {
            DomainValidationException.ValidateAll(new List<(bool condition, string errorMessage)>
            {
                (condition: string.IsNullOrEmpty(socialId), "O SocialId é obrigatório"),
                (condition: string.IsNullOrEmpty(token), "O Token é obrigatório"),
            });
        }
    }
}

