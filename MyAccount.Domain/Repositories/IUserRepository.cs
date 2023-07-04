using System;
using MyAccount.Domain.Entities;

namespace MyAccount.Domain.Repositories
{
	public interface IUserRepository
	{
		public Task Create(User user);
		public Task<User?> getByGuid(Guid guid);
		public Task<User?> getByEmail(Guid guid);
		public Task<User?> getByPhoneNumber(Guid guid);
        public Task Update(User user);
	}
}

