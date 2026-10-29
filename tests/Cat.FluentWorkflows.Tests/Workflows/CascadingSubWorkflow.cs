using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record CascadingSubWorkflowState : ICatWorkflowState<CascadingSubWorkflowState>;

public class CascadingSubWorkflow : ICatWorkflow<CascadingSubWorkflowState>
{
    public void Build(ICatWorkflowBuilder<CascadingSubWorkflowState> builder)
    {
        builder.BreakCascade();
    }
}
