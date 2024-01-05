using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Templates;
using PracticeASPNET.Domain.Enums;
using System;

namespace PracticeASPNET.Tests.Domain.Entities.Templates
{
    public class WorkflowStepTemplateTests
    {
        private readonly IFixture _fixture;

        public WorkflowStepTemplateTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnWorkflowStepTemplate()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var title = "Name";
            var order = 1;
            var comment = _fixture.Create<string>();
            var userId = _fixture.Create<Guid?>();
            var roleId = _fixture.Create<Guid?>();
            var status = _fixture.Create<Status>();

            // Act
            var workflowStepTemplate = new WorkflowStepTemplate(id, title, order, comment, userId, roleId, status);

            // Assert
            Assert.NotNull(workflowStepTemplate);
            Assert.Equal(id, workflowStepTemplate.Id);
            Assert.Equal(title, workflowStepTemplate.Title);
            Assert.Equal(order, workflowStepTemplate.Order);
            Assert.Equal(userId, workflowStepTemplate.UserId);
            Assert.Equal(roleId, workflowStepTemplate.RoleId);
            Assert.Equal(comment, workflowStepTemplate.Comment);
            Assert.Equal(status, workflowStepTemplate.Status);
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnWorkflowStep()
        {
            // Arrange
            var title = "Name";
            var order = 1;
            var comment = _fixture.Create<string>();
            var userId = _fixture.Create<Guid?>();
            var roleId = _fixture.Create<Guid?>();

            // Act
            var workflowStep = WorkflowStepTemplate.Create(title, order, comment, userId, roleId);

            // Assert
            Assert.NotNull(workflowStep);
            Assert.Equal(title, workflowStep.Title);
            Assert.Equal(order, workflowStep.Order);
            Assert.Equal(userId, workflowStep.UserId);
            Assert.Equal(roleId, workflowStep.RoleId);
            Assert.Equal(comment, workflowStep.Comment);
        }
    }
}