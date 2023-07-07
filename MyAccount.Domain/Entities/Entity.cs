using System;
namespace MyAccount.Domain.Entities
{
	public abstract class Entity
	{
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }
    }
}