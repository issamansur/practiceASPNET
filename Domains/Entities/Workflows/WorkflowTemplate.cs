using practiceASPNET.Domains.Errors;

namespace practiceASPNET.Domains;

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