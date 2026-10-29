using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record IfBreakFromCurrentFlowOnlyFlowState : ICatWorkflowState<IfBreakFromCurrentFlowOnlyFlowState>
{
    public List<string> Trace { get; } = [];
}

public class IfBreakFromCurrentFlowOnlyFlow : ICatWorkflow<IfBreakFromCurrentFlowOnlyFlowState>
{
    public void Build(ICatWorkflowBuilder<IfBreakFromCurrentFlowOnlyFlowState> builder)
    {
        builder.If(_ => true, t => t.BreakFromCurrentFlowOnly());
        builder.Run(s => s.Trace.Add("end"));
    }
}
