using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record UnregisteredFlowState : ICatWorkflowState<UnregisteredFlowState>;

/// <summary>
/// An internal workflow. The module only scans public classes, so nobody registers this one.
/// </summary>
internal class UnregisteredFlow : ICatWorkflow<UnregisteredFlowState>
{
    public void Build(ICatWorkflowBuilder<UnregisteredFlowState> builder)
    {
    }
}
