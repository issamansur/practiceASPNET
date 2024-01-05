using PracticeASPNET.Domain.Entities.Templates;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain.Entities.Requests;

public class Workflow
{
    public Guid Id { get; private init; }
    public Guid WorkflowTemplateId { get; private init; }
    public string Title { get; private set; }

    public List<WorkflowStep> Steps { get; private set; }

    public Workflow(Guid id, 
        Guid workflowTemplateId, 
        string title, 
        List<WorkflowStep> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(workflowTemplateId);
        Validator.IsValidName(title);
        Validator.IsValidCollection(steps, 3);

        Id = id;
        WorkflowTemplateId = workflowTemplateId;
        Title = title;
        Steps = steps;
    }

    public static Workflow Create(string title, WorkflowTemplate workflowTemplate)
    {
        Guid workflowTemplateId = workflowTemplate.Id;
        List<WorkflowStep> steps = workflowTemplate.Steps.Select(step => 
            WorkflowStep.Create(
                step.Title, 
                step.Order,
                step.Comment,  
                step.UserId, 
                step.RoleId
                )
            ).ToList();
        return new Workflow(Guid.NewGuid(), workflowTemplateId, title, steps);
    }
}