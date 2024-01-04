using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Requests.Events;
using PracticeASPNET.Domain.Entities.Users;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Enums;
using System.Linq;

namespace PracticeASPNET.Tests.Domain.Entities.Requests
{
    public class RequestTests
    {
        private readonly IFixture _fixture;

        public RequestTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnRequest()
        {
            // Arrange
            var user = _fixture.Create<User>();
            var document = _fixture.Create<Document>();
            var workflow = _fixture.Create<Workflow>();

            // Act
            var request = Request.Create(user, document, workflow);

            // Assert
            Assert.NotNull(request);
            Assert.Equal(user, request.User);
            Assert.Equal(document, request.Document);
            Assert.Equal(workflow, request.Workflow);
            Assert.Equal(Status.Pending, request.Status);
            Assert.Equal(0, request.CurrentStep);
        }

        [Fact]
        public void AddEvent_ValidEvent_ShouldAddEventToList()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var @event = _fixture.Create<Event>();

            // Act
            request.AddEvent(@event);

            // Assert
            Assert.Contains(@event, request.Events);
        }

        [Fact]
        public void SetDocument_ValidDocument_ShouldSetDocument()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var document = _fixture.Create<Document>();

            // Act
            request.SetDocument(document);

            // Assert
            Assert.Equal(document, request.Document);
        }

        [Fact]
        public void Approve_ValidUser_ShouldApproveRequest()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var user = _fixture.Create<User>();

            // Act
            request.Approve(user);

            // Assert
            Assert.Contains(request.Events, e => e is RequestApproveEvent);
        }

        [Fact]
        public void Reject_ValidUser_ShouldRejectRequest()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var user = _fixture.Create<User>();

            // Act
            request.Reject(user);

            // Assert
            Assert.Contains(request.Events, e => e is RequestRejectEvent);
        }

        [Fact]
        public void Restart_ValidUser_ShouldRestartRequest()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var user = _fixture.Create<User>();

            // Act
            request.Restart(user);

            // Assert
            Assert.Contains(request.Events, e => e is RequestRestartEvent);
        }

        [Fact]
        public void Freeze_ValidUser_ShouldFreezeRequest()
        {
            // Arrange
            var request = _fixture.Create<Request>();
            var user = _fixture.Create<User>();

            // Act
            request.Freeze(user);

            // Assert
            Assert.Contains(request.Events, e => e is RequestFreezeEvent);
        }
    }
}