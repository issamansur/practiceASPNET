using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain;

public class Workflow
{
    public Guid WorkflowTemplateId { get; init; }
    public string Name { get; set; }

    public List<WorkflowStep> Steps { get; private set; }

    public Workflow(Guid id, string name, List<WorkflowStep> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(name);

        WorkflowTemplateId = id;
        Name = name;
        Steps = steps;
    }

    static public Workflow Create(string name)
    {
        return new Workflow(Guid.NewGuid(), name, new List<WorkflowStep>());
    }
}