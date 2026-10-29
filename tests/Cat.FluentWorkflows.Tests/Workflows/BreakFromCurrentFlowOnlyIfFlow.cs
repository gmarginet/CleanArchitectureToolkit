using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakFromCurrentFlowOnlyIfFlowState : ICatWorkflowState<BreakFromCurrentFlowOnlyIfFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakFromCurrentFlowOnlyIfFlow : ICatWorkflow<BreakFromCurrentFlowOnlyIfFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakFromCurrentFlowOnlyIfFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakFromCurrentFlowOnlyIf(s => s.Number == 1);
        builder.Run(s => s.Trace.Add("2"));
    }
}
