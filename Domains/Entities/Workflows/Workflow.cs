public class Workflow: WorkflowTemplate
{
    [Key]
    public int WorkflowTemplateId { get; set; }
    public string Name { get; set; }
    
    public virtual List<WorkflowStep> Steps { get; set; }

    public Workflow(int id, string name, List<WorkflowStep> steps)
    {
        WorkflowTemplateId = id;
        Name = name;
        Steps = steps;
    }

    static public Workflow Create(string name) {
        return Workflow(name, new List<WorkflowStep>);
    }
}