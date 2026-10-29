using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakCascadeFlowState : ICatWorkflowState<BreakCascadeFlowState>
{
    public List<string> Trace { get; } = [];
}

public class BreakCascadeFlow : ICatWorkflow<BreakCascadeFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakCascadeFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakCascade();
        builder.Run(s => s.Trace.Add("2"));
    }
}
