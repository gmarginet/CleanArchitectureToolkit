using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SubWorkflowBreakCascadeFlowState : ICatWorkflowState<SubWorkflowBreakCascadeFlowState>, ICatHasSubWorkflowState<CascadingSubWorkflowState>
{
    public List<string> Trace { get; } = [];
    public CascadingSubWorkflowState WorkflowState { get; set; } = new();
}

public class SubWorkflowBreakCascadeFlow : ICatWorkflow<SubWorkflowBreakCascadeFlowState>
{
    public void Build(ICatWorkflowBuilder<SubWorkflowBreakCascadeFlowState> builder)
    {
        builder.Run<CascadingSubWorkflow, CascadingSubWorkflowState, SubWorkflowBreakCascadeFlowState>();
        builder.Run(s => s.Trace.Add("main continues"));
    }
}
