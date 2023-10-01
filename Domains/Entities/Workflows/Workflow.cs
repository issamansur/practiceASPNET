namespace practiceASPNET.Domains;

public class Workflow : WorkflowTemplate
{
    public Guid WorkflowTemplateId { get; set; }
    public string Name { get; set; }

    public virtual List<WorkflowStep> Steps { get; set; }

    public Workflow(Guid id, string name, List<WorkflowStep> steps)
    {
        WorkflowTemplateId = id;
        Name = name;
        Steps = steps;
    }

    static public Workflow Create(string name)
    {
        return new Workflow(Guid.NewGuid(), name, new List<WorkflowStep>());
    }
}