public class Request
{
    public int Id { get; set; }
    private List<IEvent> Events { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public int WorkflowId { get; set; }
    public Workflow Workflow { get; set; }

    public bool IsApproved()
    {
        // TODO
        return false;
    }

    public bool IsReject()
    {
        // TODO
        return false;
    }

    public void Approve(User user)
    {
        // TODO
    }

    public void Reject(User user)
    {
        // TODO
    }

    public void Restart()
    {
        // TODO
    }
}