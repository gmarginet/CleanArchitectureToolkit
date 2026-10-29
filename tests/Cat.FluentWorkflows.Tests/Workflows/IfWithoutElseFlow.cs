using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record IfWithoutElseFlowState : ICatWorkflowState<IfWithoutElseFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class IfWithoutElseFlow : ICatWorkflow<IfWithoutElseFlowState>
{
    public void Build(ICatWorkflowBuilder<IfWithoutElseFlowState> builder)
    {
        builder.If(s => s.Number > 0, t => t.Run(s => s.Trace.Add("then")));
        builder.Run(s => s.Trace.Add("end"));
    }
}
