using System;
using Bogus;
using FluentAssertions;
using MyAccount.Domain.Entities;
using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;

namespace MyAccount.Tests.Unity.Entities
{
	public class SocialProviderEntityTest
	{
		private Faker fake = new Faker("pt_BR");

		[Fact]
		public void CreateSocialProvider_WithValidParams_ResultObjectValidState()
		{
			Action action = () => new SocialProvider(
                                fake.Person.FirstName.ToLower(),
                                fake.Random.Bool());
         

			action.Should().NotThrow<DomainValidationException>();
		}

        [Fact]
        public void CreateSocialProvider_EmptyName_DomainValidationException()
        {
            Action action = () =>
            {
                SocialProvider socialProvider = new SocialProvider(
                                "",
                                fake.Random.Bool());
            };

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(SocialProviderValidationMessages.NameEmptyOrNull);
        }
    }
}

