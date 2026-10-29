using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SimpleForeachFlowState : ICatWorkflowState<SimpleForeachFlowState>
{
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Trace { get; } = [];
}

public class SimpleForeachFlow : ICatWorkflow<SimpleForeachFlowState>
{
    public void Build(ICatWorkflowBuilder<SimpleForeachFlowState> builder)
    {
        builder.Foreach(s => s.Items, f => f.Run(fs => fs.ParentWorkflowState.Trace.Add("item" + fs.CurrentItem)));
        builder.Run(s => s.Trace.Add("end"));
    }
}
