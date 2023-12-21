using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain;

public class Workflow
{
    public Guid WorkflowTemplateId { get; private init; }
    public string Name { get; private set; }

    public List<WorkflowStep> Steps { get; private set; }

    public Workflow(Guid id, string name, List<WorkflowStep> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);

        WorkflowTemplateId = id;
        Name = name;
        Steps = steps;
    }

    public static Workflow Create(string name)
    {
        return new Workflow(Guid.NewGuid(), name, new List<WorkflowStep>());
    }
}