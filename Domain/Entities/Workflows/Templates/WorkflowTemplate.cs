using practiceASPNET.Domain.Errors;
using practiceASPNET.Domain.Requests;

namespace practiceASPNET.Domain.Entities.Workflows.Templates;

public class WorkflowTemplate
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public List<WorkflowStepTemplate> Steps { get; init; }

    public WorkflowTemplate()
    {

    }

    public Request Create(User user, Document document)
    {
        // TODO
        return new Request();
    }
}