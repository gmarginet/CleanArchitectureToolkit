using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SwitchFallThroughFlowState : ICatWorkflowState<SwitchFallThroughFlowState>
{
    public TestKind Kind { get; set; }
    public List<string> Trace { get; } = [];
}

public class SwitchFallThroughFlow : ICatWorkflow<SwitchFallThroughFlowState>
{
    public void Build(ICatWorkflowBuilder<SwitchFallThroughFlowState> builder)
    {
        builder.Switch(s => s.Kind, c =>
        {
            c.Case(TestKind.A);
            c.Case(TestKind.B, x => x.Run(s => s.Trace.Add("A or B")));
        });
    }
}
