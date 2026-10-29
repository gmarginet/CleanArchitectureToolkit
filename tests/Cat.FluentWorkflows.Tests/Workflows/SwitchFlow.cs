using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SwitchFlowState : ICatWorkflowState<SwitchFlowState>
{
    public TestKind Kind { get; set; }
    public List<string> Trace { get; } = [];
}

public class SwitchFlow : ICatWorkflow<SwitchFlowState>
{
    public void Build(ICatWorkflowBuilder<SwitchFlowState> builder)
    {
        builder.Switch(s => s.Kind, c =>
        {
            c.Case(TestKind.A, x => x.Run(s => s.Trace.Add("A")));
            c.Case(TestKind.B, x => x.Run(s => s.Trace.Add("B")));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
