using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record UnregisteredStepFlowState : ICatWorkflowState<UnregisteredStepFlowState>;

/// <summary>
/// Uses a step body that nobody registered.
/// </summary>
public class UnregisteredStepFlow : ICatWorkflow<UnregisteredStepFlowState>
{
    public void Build(ICatWorkflowBuilder<UnregisteredStepFlowState> builder)
    {
        builder.Run<UnregisteredStepFlowState, UnregisteredStep>();
    }
}
