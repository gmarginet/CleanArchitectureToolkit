using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SubWorkflowBreakFromCurrentFlowOnlyFlowState : ICatWorkflowState<SubWorkflowBreakFromCurrentFlowOnlyFlowState>, ICatHasSubWorkflowState<BreakingSubWorkflowState>
{
    public List<string> Trace { get; } = [];
    public BreakingSubWorkflowState WorkflowState { get; set; } = new();
}

public class SubWorkflowBreakFromCurrentFlowOnlyFlow : ICatWorkflow<SubWorkflowBreakFromCurrentFlowOnlyFlowState>
{
    public void Build(ICatWorkflowBuilder<SubWorkflowBreakFromCurrentFlowOnlyFlowState> builder)
    {
        builder.Run<BreakingSubWorkflow, BreakingSubWorkflowState, SubWorkflowBreakFromCurrentFlowOnlyFlowState>();
        builder.Run(s => s.Trace.Add(s.WorkflowState.Message));
    }
}
