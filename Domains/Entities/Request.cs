public class Request
{
    public GUID Id { get; set; }
    public int UserId { get; set; }
    public int DocumentId { get; set; }
    public int WorkflowId { get; set; }

    
    public virtual User User { get; set; }
    public virtual Document Document { get; set; }
    public virtual Workflow Workflow { get; set; }
    private virtual List<IEvent> Events { get; set; }

    public Request(GUID id, int userId, int documentId, int workflowId)
    {
        Id = id;
        UserId = userId;
        DocumentId = documentId;
        WorkflowId = workflowId;
    }

    public Request Create(int userId, int documentId, int workflowId)
    {
        return new Request(GUID.new(), int userId, int documentId, int workflowId);
    }

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