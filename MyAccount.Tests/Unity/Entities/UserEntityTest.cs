using System;
using MyAccount.Domain.Entities;
using FluentAssertions;
using MyAccount.Domain.Validation;
using MyAccount.Domain.Resources.Messages.Validations;

namespace MyAccount.Tests.Unity.Entities
{
    public class UserEntityTest
    {
        [Fact]
        public void CreateUser_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new User(
                Guid.NewGuid(),
                "User Name",
                "user@mail.com",
                "12345678");

            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateUser_TooShortPassword_DomainValidationException()
        {
            Action action = () => new User(
                Guid.NewGuid(),
                "User Name",
                "user@mail.com",
                "1234567");

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.PasswordToShort);
        }

        [Fact]
        public void CreateUser_EmptyName_DomainValidationException()
        {
            Action action = () => new User(
                Guid.NewGuid(),
                "",
                "user@mail.com",
                "12345678");

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.NameNullOrEmpty);
        }

        [Fact]
        public void CreateUser_TooShortName_DomainValidationException()
        {
            Action action = () => new User(
                Guid.NewGuid(),
                "Name",
                "user@mail.com",
                "12345678");

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.NameTooShort);
        }

        [Fact]
        public void CreateUser_EmptyEmail_DomainValidationException()
        {
            Action action = () => new User(
                Guid.NewGuid(),
                "User Name",
                "",
                "12345678");

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.EmailNullOrEmpty);
        }

    }
}

