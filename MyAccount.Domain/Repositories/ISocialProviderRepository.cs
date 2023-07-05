using MyAccount.Domain.Entities;

namespace MyAccount.Domain.Repositories
{
	public interface ISocialProviderRepository
	{
		public Task Create(SocialProvider socialProvider);
		public Task Update(SocialProvider socialProvider);
		public Task getAll(SocialProvider socialProvider);
    }
}

