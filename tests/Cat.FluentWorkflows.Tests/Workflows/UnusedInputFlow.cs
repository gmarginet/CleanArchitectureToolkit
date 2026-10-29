using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record UnusedInputFlowState : ICatWorkflowState<UnusedInputFlowState>
{
    public bool StepSawNull { get; set; }
    public int StepNumber { get; set; }
}

/// <summary>
/// Without an input, the step keeps the value it started with.
/// </summary>
public class UnusedInputFlow : ICatWorkflow<UnusedInputFlowState>
{
    public void Build(ICatWorkflowBuilder<UnusedInputFlowState> builder)
    {
        builder.Run<UnusedInputFlowState, NullableInputStep>()
            .Output(step => step.Number, s => s.StepNumber)
            .Output(step => step.ValueWasNull, s => s.StepSawNull);
    }
}
