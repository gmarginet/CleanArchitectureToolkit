using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakingSubWorkflowState : ICatWorkflowState<BreakingSubWorkflowState>
{
    public string Message { get; set; } = "";
}

public class BreakingSubWorkflow : ICatWorkflow<BreakingSubWorkflowState>
{
    public void Build(ICatWorkflowBuilder<BreakingSubWorkflowState> builder)
    {
        builder.Run(s => s.Message = "before");
        builder.BreakFromCurrentFlowOnly();
        builder.Run(s => s.Message = "after");
    }
}
