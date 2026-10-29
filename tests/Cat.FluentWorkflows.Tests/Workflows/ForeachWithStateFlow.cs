using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ForeachWithStateFlowState : ICatWorkflowState<ForeachWithStateFlowState>
{
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Trace { get; } = [];
}

public record ForeachWithStateFlowItemState : ICatForeachState<int, ForeachWithStateFlowState>, ICatWorkflowState<ForeachWithStateFlowItemState>
{
    public int CurrentItem { get; set; }
    public ForeachWithStateFlowState ParentWorkflowState { get; set; } = null!;
}

public class ForeachWithStateFlow : ICatWorkflow<ForeachWithStateFlowState>
{
    public void Build(ICatWorkflowBuilder<ForeachWithStateFlowState> builder)
    {
        builder.Foreach<ForeachWithStateFlowState, int, ForeachWithStateFlowItemState>(s => s.Items,
            f => f.Run(fs => fs.ParentWorkflowState.Trace.Add("item" + fs.CurrentItem)));
        builder.Run(s => s.Trace.Add("end"));
    }
}
