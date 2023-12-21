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
        Validator.IsValidCollection(steps, "WorkflowStepTemplate", 3);

        Id = id;
        Name = name;
        Steps = steps;
    }

    public Request Create(User user, Document document)
    {
        // TODO
        return new Request();
    }
}