using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SwitchDuplicateCaseFlowState : ICatWorkflowState<SwitchDuplicateCaseFlowState>
{
    public TestKind Kind { get; set; }
    public List<string> Trace { get; } = [];
}

/// <summary>
/// Defines the same case twice, which is not allowed.
/// </summary>
public class SwitchDuplicateCaseFlow : ICatWorkflow<SwitchDuplicateCaseFlowState>
{
    public void Build(ICatWorkflowBuilder<SwitchDuplicateCaseFlowState> builder)
    {
        builder.Switch(s => s.Kind, c =>
        {
            c.Case(TestKind.A, x => x.Run(s => s.Trace.Add("first")));
            c.Case(TestKind.A, x => x.Run(s => s.Trace.Add("second")));
        });
    }
}
