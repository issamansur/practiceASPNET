public class Workflow: WorkflowTemplate
{
    public int Id { get; set; }
    public int WorkflowTemplateId { get; set; }
    public string Name { get; set; }
    public List<WorkflowStep> Steps { get; set; }
}