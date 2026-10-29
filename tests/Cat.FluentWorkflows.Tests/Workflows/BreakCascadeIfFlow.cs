using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakCascadeIfFlowState : ICatWorkflowState<BreakCascadeIfFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakCascadeIfFlow : ICatWorkflow<BreakCascadeIfFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakCascadeIfFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakCascadeIf(s => s.Number == 1);
        builder.Run(s => s.Trace.Add("2"));
    }
}
