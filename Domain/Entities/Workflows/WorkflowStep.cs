using practiceASPNET.Domain.Enums;
using practiceASPNET.Utils;

namespace practiceASPNET.Domain;

public class WorkflowStep
{
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public int Order { get; private set; }
    public User? User { get; private set; }
    public Guid? RoleId { get; private set; }
    public string Comment { get; private set; }
    public Status Status { get; private set; }

    public WorkflowStep(
        Guid id, 
        string title, 
        int order,
        string comment, 
        User? user, 
        Guid? roleId, 
        Status status)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(title, "Title");
        if (order < 0)
            throw new ArgumentException("Order must be greater than 0");
        if (user is not null && roleId is not null)
            throw new ArgumentException("User and RoleId cannot be set at the same time");
        if (user is null && roleId is null)
            throw new ArgumentException("User or RoleId must be set");
        ArgumentNullException.ThrowIfNull(status);

        Id = id;
        Title = title;
        Order = order;
        User = user;
        RoleId = roleId;
        Comment = comment;
        Status = status;
    }

    static public WorkflowStep Create(
        string title, 
        int order,
        string comment = "",
        User? user = null, 
        Guid? roleId = null)
    {
        return new WorkflowStep(
            Guid.NewGuid(), 
            title, 
            order, 
            comment,  
            user, 
            roleId,
            Status.Pending);
    }

    public void SetStatus(User user, Status status)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(status);

        if (User is not null && User.Id != user.Id ||
            RoleId is not null && RoleId != user.RoleId)
            throw new ArgumentException("User is not allowed to change this step status");

        User = user;
        RoleId = null;

        Status = status;
    }
}