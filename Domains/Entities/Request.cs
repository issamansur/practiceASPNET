namespace practiceASPNET.Domains;

public class Request
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int DocumentId { get; set; }
    public int WorkflowId { get; set; }


    public User User { get; set; }
    public Document Document { get; set; }
    public Workflow Workflow { get; set; }
    private List<IEvent> Events { get; set; }

    public Request(Guid id, int userId, int documentId, int workflowId)
    {
        Id = id;
        UserId = userId;
        DocumentId = documentId;
        WorkflowId = workflowId;
    }

    public Request Create(int userId, int documentId, int workflowId)
    {
        return new Request(Guid.NewGuid(), userId, documentId, workflowId);
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