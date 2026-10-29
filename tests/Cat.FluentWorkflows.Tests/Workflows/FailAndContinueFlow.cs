using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record FailAndContinueFlowState : ICatWorkflowState<FailAndContinueFlowState>
{
    public List<string> Trace { get; } = [];
}

public class FailAndContinueFlow : ICatWorkflow<FailAndContinueFlowState>
{
    public void Build(ICatWorkflowBuilder<FailAndContinueFlowState> builder)
    {
        builder.Run<FailAndContinueFlowState, FailAndContinueStep>();
        builder.Run(s => s.Trace.Add("after"));
    }
}
