using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Users;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Enums;
using System;

namespace PracticeASPNET.Tests.Domain.Entities.Requests
{
    public class WorkflowStepTests
    {
        private readonly IFixture _fixture;

        public WorkflowStepTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnWorkflowStep()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var title = _fixture.Create<string>();
            var order = _fixture.Create<int>();
            var comment = _fixture.Create<string>();
            var userId = _fixture.Create<Guid?>();
            var roleId = _fixture.Create<Guid?>();
            var status = _fixture.Create<Status>();

            // Act
            var workflowStep = new WorkflowStep(id, title, order, comment, userId, roleId, status);

            // Assert
            Assert.NotNull(workflowStep);
            Assert.Equal(id, workflowStep.Id);
            Assert.Equal(title, workflowStep.Title);
            Assert.Equal(order, workflowStep.Order);
            Assert.Equal(userId, workflowStep.UserId);
            Assert.Equal(roleId, workflowStep.RoleId);
            Assert.Equal(comment, workflowStep.Comment);
            Assert.Equal(status, workflowStep.Status);
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnWorkflowStep()
        {
            // Arrange
            var title = _fixture.Create<string>();
            var order = _fixture.Create<int>();
            var comment = _fixture.Create<string>();
            var userId = _fixture.Create<Guid?>();
            var roleId = _fixture.Create<Guid?>();

            // Act
            var workflowStep = WorkflowStep.Create(title, order, comment, userId, roleId);

            // Assert
            Assert.NotNull(workflowStep);
            Assert.Equal(title, workflowStep.Title);
            Assert.Equal(order, workflowStep.Order);
            Assert.Equal(userId, workflowStep.UserId);
            Assert.Equal(roleId, workflowStep.RoleId);
            Assert.Equal(comment, workflowStep.Comment);
        }

        [Fact]
        public void SetStatus_ValidUserAndStatus_ShouldSetStatus()
        {
            // Arrange
            var workflowStep = _fixture.Create<WorkflowStep>();
            var user = _fixture.Create<User>();
            var status = _fixture.Create<Status>();

            // Act
            workflowStep.SetStatus(user, status);

            // Assert
            Assert.Equal(user.Id, workflowStep.UserId);
            Assert.Equal(status, workflowStep.Status);
        }

        [Fact]
        public void SetComment_ValidUserAndComment_ShouldSetComment()
        {
            // Arrange
            var workflowStep = _fixture.Create<WorkflowStep>();
            var user = _fixture.Create<User>();
            var comment = _fixture.Create<string>();

            // Act
            workflowStep.SetComment(user, comment);

            // Assert
            Assert.Equal(user.Id, workflowStep.UserId);
            Assert.Equal(comment, workflowStep.Comment);
        }
    }
}