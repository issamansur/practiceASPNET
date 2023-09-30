using practiceASPNET.Domains.Entities.Users;

namespace practiceASPNET.Domains.Entities.Workflows;

public class WorkflowTemplate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<WorkflowStepTemplate> Steps { get; set; }

    public Request Create(User user, Document document)
    {
        // TODO
        return new Request();
    }

    public void AddStep(){
        // TODO
    }
    public void EditStep(){
        // TODO
    }
}