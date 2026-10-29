using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakFromCurrentFlowOnlyIfWithLoggerFlowState : ICatWorkflowState<BreakFromCurrentFlowOnlyIfWithLoggerFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakFromCurrentFlowOnlyIfWithLoggerFlow : ICatWorkflow<BreakFromCurrentFlowOnlyIfWithLoggerFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakFromCurrentFlowOnlyIfWithLoggerFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakFromCurrentFlowOnlyIf((_, s) => s.Number == 1);
        builder.Run(s => s.Trace.Add("2"));
    }
}
