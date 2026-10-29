using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record FailAndContinueInIfFlowState : ICatWorkflowState<FailAndContinueInIfFlowState>
{
    public List<string> Trace { get; } = [];
}

public class FailAndContinueInIfFlow : ICatWorkflow<FailAndContinueInIfFlowState>
{
    public void Build(ICatWorkflowBuilder<FailAndContinueInIfFlowState> builder)
    {
        builder.If(_ => true, t => t.Run<FailAndContinueInIfFlowState, FailAndContinueStep>());
        builder.Run(s => s.Trace.Add("end"));
    }
}
