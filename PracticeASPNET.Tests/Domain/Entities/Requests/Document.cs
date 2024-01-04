using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Requests;

namespace PracticeASPNET.Tests.Domain.Entities.Requests
{
    public class DocumentTests
    {
        private readonly IFixture _fixture;

        public DocumentTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnDocument()
        {
            // Arrange
            var name = _fixture.Create<string>();
            var email = _fixture.Create<string>();

            // Act
            var document = Document.Create(name, email);

            // Assert
            Assert.NotNull(document);
            Assert.Equal(name, document.Name);
            Assert.Equal(email, document.Email);
        }

        [Theory]
        [InlineData(null, "validemail@example.com")]
        [InlineData("Valid Name", null)]
        [InlineData(null, null)]
        public void Create_InvalidParameters_ShouldThrowException(string name, string email)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Document.Create(name, email));
        }
    }
}