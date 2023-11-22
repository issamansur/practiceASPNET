namespace practiceASPNET.Domains;

public class WorkflowStep
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
    public string Comment { get; set; }

    private void SetStatus()
    {
        // TODO
    }
}