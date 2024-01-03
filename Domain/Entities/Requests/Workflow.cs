using PracticeASPNET.Domain.Entities.Workflows.Templates;
using PracticeASPNET.Domain.Enums;
using PracticeASPNET.Utils;

namespace PracticeASPNET.Domain;

public class Workflow
{
    public Guid Id { get; private init; }
    public Guid WorkflowTemplateId { get; private init; }
    public string Name { get; private set; }

    public List<WorkflowStep> Steps { get; private set; }

    public Workflow(Guid id, 
        Guid workflowTemplateId, 
        string name, 
        List<WorkflowStep> steps)
    {
        Validator.IsValidGuid(id);
        Validator.IsValidGuid(workflowTemplateId);
        Validator.IsValidName(name);
        Validator.IsValidCollection(steps, 3);

        Id = id;
        WorkflowTemplateId = workflowTemplateId;
        Name = name;
        Steps = steps;
    }

    public static Workflow Create(string name, WorkflowTemplate workflowTemplate)
    {
        Guid workflowTemplateId = workflowTemplate.Id;
        List<WorkflowStep> steps = workflowTemplate.Steps.Select(step => 
            WorkflowStep.Create(
                step.Name, 
                step.Order,
                step.Comment,  
                step.UserId, 
                step.RoleId
                )
            ).ToList();
        return new Workflow(Guid.NewGuid(), workflowTemplateId, name, steps);
    }
}