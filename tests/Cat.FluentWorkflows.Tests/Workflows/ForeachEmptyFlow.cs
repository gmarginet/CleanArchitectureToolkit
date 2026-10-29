using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ForeachEmptyFlowState : ICatWorkflowState<ForeachEmptyFlowState>
{
    public List<int> Items { get; set; } = [];
    public List<string> Trace { get; } = [];
}

public class ForeachEmptyFlow : ICatWorkflow<ForeachEmptyFlowState>
{
    public void Build(ICatWorkflowBuilder<ForeachEmptyFlowState> builder)
    {
        builder.Foreach(s => s.Items, f => f.Run(fs => fs.ParentWorkflowState.Trace.Add("never")));
        builder.Run(s => s.Trace.Add("end"));
    }
}
