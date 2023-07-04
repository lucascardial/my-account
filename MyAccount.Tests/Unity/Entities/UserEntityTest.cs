using System;
using MyAccount.Domain.Entities;
using FluentAssertions;
using MyAccount.Domain.Validation;
using MyAccount.Domain.Resources.Messages.Validations;
using Bogus;

namespace MyAccount.Tests.Unity.Entities
{
    public class UserEntityTest
    {
        [Fact]
        public void CreateUser_WithValidParameters_ResultObjectValidState()
        {
            var fake = new Faker("pt_BR");

            var id = fake.Random.Guid();
            var name = fake.Person.FullName;
            var email = fake.Person.Email;
            var password = fake.Random.AlphaNumeric(8);
            
            Action action = () => new User(
                id,
                name,
                email,
                password);

            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateUser_TooShortPassword_DomainValidationException()
        {
            var fake = new Faker("pt_BR");
            
            var id = fake.Random.Guid();
            var name = fake.Person.FullName;
            var email = fake.Person.Email;
            var password = fake.Random.AlphaNumeric(5);

            Action action = () => new User(
                id,
                name,
                email,
                password);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.PasswordToShort);
        }

        [Fact]
        public void CreateUser_EmptyName_DomainValidationException()
        {
            var fake = new Faker("pt_BR");

            var id = fake.Random.Guid();
            var name = fake.Random.AlphaNumeric(0);
            var email = fake.Person.Email;
            var password = fake.Random.AlphaNumeric(8);
            Action action = () => new User(
                id,
                name,
                email,
                password);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.NameNullOrEmpty);
        }

        [Fact]
        public void CreateUser_TooShortName_DomainValidationException()
        {
            var fake = new Faker("pt_BR");

            var id = fake.Random.Guid();
            var name = fake.Random.AlphaNumeric(4);
            var email = fake.Person.Email;
            var password = fake.Random.AlphaNumeric(8);

            Action action = () => new User(
                id,
                name,
                email,
                password);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.NameTooShort);
        }

        [Fact]
        public void CreateUser_EmptyEmail_DomainValidationException()
        {
            var fake = new Faker("pt_BR");

            var id = fake.Random.Guid();
            var name = fake.Person.FullName;
            var email = fake.Random.AlphaNumeric(0);
            var password = fake.Random.AlphaNumeric(8);

            Action action = () => new User(
                id,
                name,
                email,
                password);

            var exception = Assert.Throws<DomainValidationException>(action);

            exception.Errors.Should().Contain(UserValidationMessages.EmailNullOrEmpty);
        }

    }
}

