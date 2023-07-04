using System;
using MyAccount.Domain.Entities;

namespace MyAccount.Domain.Repositories
{
	public interface ISocialAccountRepository
	{
		public Task Create(SocialAccount socialAccount);
		public Task Update(SocialAccount socialAccount);
		public Task<List<SocialAccount>> FindUserSocialAccounts(User user);
    }
}

