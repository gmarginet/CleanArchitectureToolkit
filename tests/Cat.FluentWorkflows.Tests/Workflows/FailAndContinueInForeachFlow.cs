using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record FailAndContinueInForeachFlowState : ICatWorkflowState<FailAndContinueInForeachFlowState>
{
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Trace { get; } = [];
}

public record FailAndContinueInForeachFlowItemState : ICatForeachState<int, FailAndContinueInForeachFlowState>, ICatWorkflowState<FailAndContinueInForeachFlowItemState>
{
    public int CurrentItem { get; set; }
    public FailAndContinueInForeachFlowState ParentWorkflowState { get; set; } = null!;
}

public class FailAndContinueInForeachFlow : ICatWorkflow<FailAndContinueInForeachFlowState>
{
    public void Build(ICatWorkflowBuilder<FailAndContinueInForeachFlowState> builder)
    {
        builder.Foreach<FailAndContinueInForeachFlowState, int, FailAndContinueInForeachFlowItemState>(s => s.Items,
            f => f.Run<FailAndContinueInForeachFlowItemState, FailAndContinueStep>());
        builder.Run(s => s.Trace.Add("end"));
    }
}
