using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Users;
using System;

namespace PracticeASPNET.Tests.Domain
{
    public class UserTests
    {
        private readonly IFixture _fixture;

        public UserTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnUser()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var roleId = _fixture.Create<Guid>();
            var name = _fixture.Create<string>();
            var email = _fixture.Create<string>();

            // Act
            var user = new User(id, roleId, name, email);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(id, user.Id);
            Assert.Equal(roleId, user.RoleId);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public void Constructor_InvalidParameters_ShouldThrowException()
        {
            // Arrange
            var id = Guid.Empty;
            var roleId = Guid.Empty;
            var name = string.Empty;
            var email = "invalid email";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User(id, roleId, name, email));
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnUser()
        {
            // Arrange
            var roleId = _fixture.Create<Guid>();
            var name = _fixture.Create<string>();
            var email = _fixture.Create<string>();

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