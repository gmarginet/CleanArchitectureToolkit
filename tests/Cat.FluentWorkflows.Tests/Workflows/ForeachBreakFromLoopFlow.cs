using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ForeachBreakFromLoopFlowState : ICatWorkflowState<ForeachBreakFromLoopFlowState>
{
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Trace { get; } = [];
}

public record ForeachBreakFromLoopFlowItemState : ICatForeachState<int, ForeachBreakFromLoopFlowState>, ICatWorkflowState<ForeachBreakFromLoopFlowItemState>
{
    public int CurrentItem { get; set; }
    public ForeachBreakFromLoopFlowState ParentWorkflowState { get; set; } = null!;
}

public class ForeachBreakFromLoopFlow : ICatWorkflow<ForeachBreakFromLoopFlowState>
{
    public void Build(ICatWorkflowBuilder<ForeachBreakFromLoopFlowState> builder)
    {
        builder.Foreach<ForeachBreakFromLoopFlowState, int, ForeachBreakFromLoopFlowItemState>(s => s.Items, f =>
        {
            f.Run(fs => fs.ParentWorkflowState.Trace.Add("item" + fs.CurrentItem));
            f.BreakFromLoopIf(fs => fs.CurrentItem == 2);
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
