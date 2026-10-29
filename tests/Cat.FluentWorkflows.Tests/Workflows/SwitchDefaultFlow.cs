using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SwitchDefaultFlowState : ICatWorkflowState<SwitchDefaultFlowState>
{
    public TestKind Kind { get; set; }
    public List<string> Trace { get; } = [];
}

public class SwitchDefaultFlow : ICatWorkflow<SwitchDefaultFlowState>
{
    public void Build(ICatWorkflowBuilder<SwitchDefaultFlowState> builder)
    {
        builder.Switch(s => s.Kind, c =>
        {
            c.Case(TestKind.A, x => x.Run(s => s.Trace.Add("A")));
            c.Default(x => x.Run(s => s.Trace.Add("default")));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
