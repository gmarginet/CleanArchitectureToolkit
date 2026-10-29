using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record NullInputFlowState : ICatWorkflowState<NullInputFlowState>
{
    public string? Text { get; set; }
    public bool StepSawNull { get; set; }
}

/// <summary>
/// A <c>null</c> in the state goes into the step as the default value, so it overwrites the preset one.
/// </summary>
public class NullInputFlow : ICatWorkflow<NullInputFlowState>
{
    public void Build(ICatWorkflowBuilder<NullInputFlowState> builder)
    {
        builder.Run<NullInputFlowState, NullableInputStep>()
            .Input(s => s.Text, step => step.Value)
            .Output(step => step.ValueWasNull, s => s.StepSawNull);
    }
}
