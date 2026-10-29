using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record RunSubWorkflowFlowState : ICatWorkflowState<RunSubWorkflowFlowState>, ICatHasSubWorkflowState<SubWorkflowState>
{
    public List<string> Trace { get; } = [];
    public SubWorkflowState WorkflowState { get; set; } = new();
}

public class RunSubWorkflowFlow : ICatWorkflow<RunSubWorkflowFlowState>
{
    public void Build(ICatWorkflowBuilder<RunSubWorkflowFlowState> builder)
    {
        builder.Run<SubWorkflow, SubWorkflowState, RunSubWorkflowFlowState>();
        builder.Run(s => s.Trace.Add(s.WorkflowState.Message));
    }
}
