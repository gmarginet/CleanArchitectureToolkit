using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record FailAndContinueInWhileFlowState : ICatWorkflowState<FailAndContinueInWhileFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class FailAndContinueInWhileFlow : ICatWorkflow<FailAndContinueInWhileFlowState>
{
    public void Build(ICatWorkflowBuilder<FailAndContinueInWhileFlowState> builder)
    {
        builder.While(s => s.Number < 2, w =>
        {
            w.Run(s => s.Number++);
            w.Run<FailAndContinueInWhileFlowState, FailAndContinueStep>();
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
