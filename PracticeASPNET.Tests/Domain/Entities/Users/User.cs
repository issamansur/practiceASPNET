using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Users;
using System;

namespace PracticeASPNET.Tests.Domain.Entities.Users
{
    public class UserTests
    {
        private readonly IFixture _fixture;

        public UserTests()
        {
            _fixture = new Fixture();
            _fixture.Add
        }

        [Theory, AutoData]
        public void Constructor_ValidParameters_ShouldReturnUser(
            [RegularExpression(@"^[a-zA-Z0-9._+-]{2, 20}$")] string validName,
            [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$")] string validEmail)
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var roleId = _fixture.Create<Guid>();
            var name = validName;
            var email = validEmail;

            // Act
            var user = new User(id, roleId, name, email);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(id, user.Id);
            Assert.Equal(roleId, user.RoleId);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
        }

        [Theory, AutoData]
        public void Constructor_InvalidParameters_ShouldThrowException(
            [RegularExpression(@"^[a-zA-Z0-9._+-]{1}$")] string invalidName,
            string invalidEmail)
        {
            // Arrange
            var id = Guid.Empty;
            var roleId = Guid.Empty;
            var name = invalidName;
            var email = invalidEmail;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User(id, roleId, name, email));
        }

        [Theory, AutoData]
        public void Create_ValidParameters_ShouldReturnUser(
            [RegularExpression(@"^[a-zA-Z0-9._+-]{2, 20}$")] string validName,
            [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z]+\.[a-zA-Z]{2,}$")] string validEmail)
        {
            // Arrange
            var roleId = _fixture.Create<Guid>();
            var name = validName;
            var email = validEmail;

            // Act
            var user = User.Create(roleId, name, email);

            // Assert
            Assert.NotNull(user);
            Assert.NotEqual(Guid.Empty, user.Id);
            Assert.Equal(roleId, user.RoleId);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
        }
    }
}