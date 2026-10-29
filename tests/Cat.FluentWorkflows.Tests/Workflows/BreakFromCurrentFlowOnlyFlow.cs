using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakFromCurrentFlowOnlyFlowState : ICatWorkflowState<BreakFromCurrentFlowOnlyFlowState>
{
    public List<string> Trace { get; } = [];
}

public class BreakFromCurrentFlowOnlyFlow : ICatWorkflow<BreakFromCurrentFlowOnlyFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakFromCurrentFlowOnlyFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakFromCurrentFlowOnly();
        builder.Run(s => s.Trace.Add("2"));
    }
}
