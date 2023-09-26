public class Workflow: WorkflowTemplate
{
    [Key]
    public int WorkflowTemplateId { get; set; }
    public string Name { get; set; }
    
    public virtual List<WorkflowStep> Steps { get; set; }
}