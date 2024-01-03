using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Workflows.Templates;

public class WorkflowTemplate
{
    public Guid Id { get; private init; }
    public string Name { get; set; }
    public List<WorkflowStepTemplate> Steps { get; private init; }

    public WorkflowTemplate(Guid id, string name, List<WorkflowStepTemplate> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);
        Validator.IsValidCollection(steps, 3);

        Id = id;
        Name = name;
        Steps = steps;
    }

    public static WorkflowTemplate Create(string name, List<WorkflowStepTemplate> steps)
    {
        return new WorkflowTemplate(Guid.NewGuid(), name, steps);
    }

    public Request Create(User user, Document document)
    {
        Workflow workflow = Workflow.Create(Name, this);
        Request request = Request.Create(user, document, workflow);
        return request;
    }
}