using System;
using FluentAssertions;
using MyAccount.Domain.Entities;
using MyAccount.Domain.Resources.Messages.Validations;
using MyAccount.Domain.Validation;

namespace MyAccount.Tests.Unity.Entities
{
    public class SocialAccountEntityTest
    {
        [Fact]
        public void CreateSocialAccount_WithValidParams_ResultObjectValidState()
        {
            var guid = Guid.NewGuid();
            var userUid = Guid.NewGuid();
            var socialProviderUid = Guid.NewGuid();
            var socialId = Guid.NewGuid().ToString();
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
            var guid = Guid.NewGuid();
            var userUid = Guid.NewGuid();
            var socialProviderUid = Guid.NewGuid();
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
            var guid = Guid.NewGuid();
            var userUid = Guid.NewGuid();
            var socialProviderUid = Guid.NewGuid();
            var socialId = "xpto-social-id";
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

