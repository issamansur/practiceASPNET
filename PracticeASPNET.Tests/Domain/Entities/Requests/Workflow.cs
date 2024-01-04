using Xunit;
using AutoFixture;
using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Entities.Templates;
using System.Linq;

namespace PracticeASPNET.Tests.Domain.Entities.Requests
{
    public class WorkflowTests
    {
        private readonly IFixture _fixture;

        public WorkflowTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldReturnWorkflow()
        {
            // Arrange
            var id = _fixture.Create<Guid>();
            var workflowTemplateId = _fixture.Create<Guid>();
            var title = _fixture.Create<string>();
            var steps = _fixture.Create<List<WorkflowStep>>();

            // Act
            var workflow = new Workflow(id, workflowTemplateId, title, steps);

            // Assert
            Assert.NotNull(workflow);
            Assert.Equal(id, workflow.Id);
            Assert.Equal(workflowTemplateId, workflow.WorkflowTemplateId);
            Assert.Equal(title, workflow.Title);
            Assert.Equal(steps, workflow.Steps);
        }

        [Fact]
        public void Create_ValidParameters_ShouldReturnWorkflow()
        {
            // Arrange
            var title = _fixture.Create<string>();
            var workflowTemplate = _fixture.Create<WorkflowTemplate>();

            // Act
            var workflow = Workflow.Create(title, workflowTemplate);

            // Assert
            Assert.NotNull(workflow);
            Assert.Equal(workflowTemplate.Id, workflow.WorkflowTemplateId);
            Assert.Equal(title, workflow.Title);
            Assert.Equal(workflowTemplate.Steps.Count, workflow.Steps.Count);
        }
    }
}