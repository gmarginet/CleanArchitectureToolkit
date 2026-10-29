using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record IfFlowState : ICatWorkflowState<IfFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class IfFlow : ICatWorkflow<IfFlowState>
{
    public void Build(ICatWorkflowBuilder<IfFlowState> builder)
    {
        builder.If(s => s.Number > 0,
            t => t.Run(s => s.Trace.Add("then")),
            e => e.Run(s => s.Trace.Add("else")));
        builder.Run(s => s.Trace.Add("end"));
    }
}
