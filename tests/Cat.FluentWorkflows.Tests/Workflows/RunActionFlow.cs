using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunActionFlowState : ICatWorkflowState<RunActionFlowState>
{
    public List<string> Trace { get; } = [];
}

public class RunActionFlow : ICatWorkflow<RunActionFlowState>
{
    public void Build(ICatWorkflowBuilder<RunActionFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("a"));
        builder.Run((_, s) => s.Trace.Add("b"));
        builder.Run(s => s.Trace.Add("c"));
    }
}
