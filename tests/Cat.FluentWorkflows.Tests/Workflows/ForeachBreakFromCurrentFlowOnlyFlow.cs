using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record ForeachBreakFromCurrentFlowOnlyFlowState : ICatWorkflowState<ForeachBreakFromCurrentFlowOnlyFlowState>
{
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Trace { get; } = [];
}

public record ForeachBreakFromCurrentFlowOnlyFlowItemState : ICatForeachState<int, ForeachBreakFromCurrentFlowOnlyFlowState>, ICatWorkflowState<ForeachBreakFromCurrentFlowOnlyFlowItemState>
{
    public int CurrentItem { get; set; }
    public ForeachBreakFromCurrentFlowOnlyFlowState ParentWorkflowState { get; set; } = null!;
}

public class ForeachBreakFromCurrentFlowOnlyFlow : ICatWorkflow<ForeachBreakFromCurrentFlowOnlyFlowState>
{
    public void Build(ICatWorkflowBuilder<ForeachBreakFromCurrentFlowOnlyFlowState> builder)
    {
        builder.Foreach<ForeachBreakFromCurrentFlowOnlyFlowState, int, ForeachBreakFromCurrentFlowOnlyFlowItemState>(s => s.Items, f =>
        {
            f.Run(fs => fs.ParentWorkflowState.Trace.Add("item" + fs.CurrentItem));
            f.BreakFromCurrentFlowOnlyIf(fs => fs.CurrentItem == 2);
            f.Run(fs => fs.ParentWorkflowState.Trace.Add("after" + fs.CurrentItem));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
