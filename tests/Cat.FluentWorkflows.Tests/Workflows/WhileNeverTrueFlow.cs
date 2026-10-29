using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record WhileNeverTrueFlowState : ICatWorkflowState<WhileNeverTrueFlowState>
{
    public List<string> Trace { get; } = [];
}

public class WhileNeverTrueFlow : ICatWorkflow<WhileNeverTrueFlowState>
{
    public void Build(ICatWorkflowBuilder<WhileNeverTrueFlowState> builder)
    {
        builder.While(_ => false, w => w.Run(s => s.Trace.Add("never")));
        builder.Run(s => s.Trace.Add("end"));
    }
}
