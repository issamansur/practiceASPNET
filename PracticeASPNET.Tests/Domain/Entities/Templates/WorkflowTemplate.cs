using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Templates;
using System;
using System.Collections.Generic;

namespace PracticeASPNET.Tests.Domain.Entities.Templates
{
    public class WorkflowTemplateTests
    {
        private readonly IFixture _fixture;

        public WorkflowTemplateTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnWorkflowTemplate()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var title = _fixture.Create<string>();
            var steps = _fixture.Create<List<WorkflowStepTemplate>>();

            // Act
            var workflowTemplate = new WorkflowTemplate(id, title, steps);

            // Assert
            Assert.NotNull(workflowTemplate);
            Assert.Equal(id, workflowTemplate.Id);
            Assert.Equal(title, workflowTemplate.Title);
            Assert.Equal(steps, workflowTemplate.Steps);
        }

        [Fact]
        public void Constructor_InvalidParameters_ShouldThrowException()
        {
            // Arrange
            var id = Guid.Empty;
            var title = string.Empty;
            var steps = new List<WorkflowStepTemplate>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new WorkflowTemplate(id, title, steps));
        }
    }
}