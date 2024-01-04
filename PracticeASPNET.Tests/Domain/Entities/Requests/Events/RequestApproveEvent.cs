using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entity.Requests.Events;
using System;

namespace PracticeASPNET.Tests.Domain.Entity.Requests.Events
{
    public class RequestApproveEventTests
    {
        private readonly IFixture _fixture;

        public RequestApproveEventTests()
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
            var event = new RequestApproveEvent(id, requestId, data);

            // Assert
            Assert.Equal(id, event.Id);
            Assert.Equal(requestId, event.RequestId);
            Assert.Equal(data, event.Data);
        }

        [Fact]
        public void Create_CreatesEventWithCorrectProperties()
        {
            // Arrange
            var requestId = _fixture.Create<Guid>();
            var data = _fixture.Create<string>();

            // Act
            var event = RequestApproveEvent.Create(requestId, data);

            // Assert
            Assert.Equal(requestId, event.RequestId);
            Assert.Equal(data, event.Data);
        }
    }
}