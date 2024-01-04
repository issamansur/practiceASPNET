using PracticeASPNET.Domain.Entities.Requests;
using PracticeASPNET.Domain.Enums;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Templates;

public class WorkflowStepTemplate
{
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public int Order { get; private set; }
    public Guid? UserId { get; private set; }
    public Guid? RoleId { get; private set; }
    public string Comment { get; private set; }
    public Status Status { get; private set; }

    public WorkflowStepTemplate(
        Guid id,
        string title,
        int order,
        string comment,
        Guid? userId, 
        Guid? roleId,
        Status status)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidName(title, "Title");
        Validator.IsValidOrder(order, 3);
        // Use Math Logic to check only one of the two is set (XOR_Logic)
        if (userId is null == roleId is null)
            throw new ArgumentException(
                "Only one of parameters (userId/roleId) is need to set"
            );
        ArgumentNullException.ThrowIfNull(status);

        Id = id;
        Title = title;
        Order = order;
        UserId = userId;
        RoleId = roleId;
        Comment = comment;
        Status = status;
    }

    public static WorkflowStep Create(
        string title,
        int order,
        string comment = "",
        Guid? userId = null,
        Guid? roleId = null)
    {
        Status status = order == 0 ? Status.Pending : Status.Frozen;
        return new WorkflowStep(
            Guid.NewGuid(),
            title,
            order,
            comment,
            userId,
            roleId,
            status);
    }
}