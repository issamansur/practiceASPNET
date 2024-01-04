// FILEPATH: /workspaces/practiceASPNET/PracticeASPNET.Tests/Domain/Entities/Requests/Events/EventTests.cs
using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entity.Requests.Events;
using System;

namespace PracticeASPNET.Tests.Domain.Entity.Requests.Events
{
    public class EventTests
    {
        private readonly IFixture _fixture;

        public EventTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var requestId = _fixture.Create<Guid>();
            var data = _fixture.Create<string>();

            // Act
            var event = new Event(id, requestId, data);

            // Assert
            Assert.Equal(id, event.Id);
            Assert.Equal(requestId, event.RequestId);
            Assert.Equal(data, event.Data);
        }

        [Fact]
        public void Constructor_ThrowsException_WhenIdIsInvalid()
        {
            // Arrange
            var id = Guid.Empty;
            var requestId = _fixture.Create<Guid>();
            var data = _fixture.Create<string>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Event(id, requestId, data));
        }

        [Fact]
        public void Constructor_ThrowsException_WhenRequestIdIsInvalid()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var requestId = Guid.Empty;
            var data = _fixture.Create<string>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Event(id, requestId, data));
        }
    }
}