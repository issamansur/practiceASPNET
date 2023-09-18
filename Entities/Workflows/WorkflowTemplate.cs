public class WorkflowTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<WorkflowStepTemplate> Steps { get; set; }

    public Request Create(User user, Document document)
    {
        // TODO
        return new Request();
    }
}