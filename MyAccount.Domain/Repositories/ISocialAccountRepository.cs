using MyAccount.Domain.Entities;

namespace MyAccount.Domain.Repositories
{
	public interface ISocialAccountRepository
	{
		public Task Create(SocialAccount socialAccount);
		public Task Update(SocialAccount socialAccount);
		public Task<IEnumerable<SocialAccount>> FindUserSocialAccounts(User user);
    }
}

