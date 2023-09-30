namespace practiceASPNET.Domains.Entities.Workflows;

public class WorkflowStepTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
}