using FluentAssertions;
using MyAccount.Domain.Entities;
using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;
using Bogus;

namespace MyAccount.Tests.Unity.Entities
{
    public class SocialAccountEntityTest
    {
        [Fact]
        public void CreateSocialAccount_WithValidParams_ResultObjectValidState()
        {
            var fake = new Faker("pt_BR");

            var guid = fake.Random.Guid();
            var userUid = fake.Random.Guid();
            var socialProviderUid = fake.Random.Guid();
            var socialId = fake.Random.AlphaNumeric(36);
            var token = "xpto-token";

            Action action = () => new SocialAccount(
                guid,
                userUid,
                socialProviderUid,
                socialId,
                token);

            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateSocialAccount_EmptySocialId_DomainValidationException()
        {
            var fake = new Faker("pt_BR");

            var guid = fake.Random.Guid();
            var userUid = fake.Random.Guid();
            var socialProviderUid = fake.Random.Guid();
            var socialId = "";
            var token = "xpto-token";

            Action action = () => new SocialAccount(
                guid,
                userUid,
                socialProviderUid,
                socialId,
                token);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception
                .Errors
                .Should()
                .Contain(SocialAccountValidationMessages.SocialIdNullOrEmpty);
        }

        [Fact]
        public void CreateSocialAccount_EmptyToken_DomainValidationException()
        {
            var fake = new Faker("pt_BR");

            var guid = fake.Random.Guid();
            var userUid = fake.Random.Guid();
            var socialProviderUid = fake.Random.Guid();
            var socialId = fake.Random.AlphaNumeric(36);
            var token = "";

            Action action = () => new SocialAccount(
                guid,
                userUid,
                socialProviderUid,
                socialId,
                token);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception
                .Errors
                .Should()
                .Contain(SocialAccountValidationMessages.TokenNullOrEmpty);
        }
    }
}

