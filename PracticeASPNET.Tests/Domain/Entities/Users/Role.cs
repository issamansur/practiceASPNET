using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Users;
using System;

namespace PracticeASPNET.Tests.Domain
{
    public class RoleTests
    {
        private readonly IFixture _fixture;

        public RoleTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnRole()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var name = _fixture.Create<string>();

            // Act
            var role = new Role(id, name);

            // Assert
            Assert.NotNull(role);
            Assert.Equal(id, role.Id);
            Assert.Equal(name, role.Name);
        }

        [Fact]
        public void Constructor_InvalidParameters_ShouldThrowException()
        {
            // Arrange
            var id = Guid.Empty;
            var name = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Role(id, name));
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnRole()
        {
            // Arrange
            var name = _fixture.Create<string>();

            // Act
            var role = Role.Create(name);

            // Assert
            Assert.NotNull(role);
            Assert.NotEqual(Guid.Empty, role.Id);
            Assert.Equal(name, role.Name);
        }
    }
}