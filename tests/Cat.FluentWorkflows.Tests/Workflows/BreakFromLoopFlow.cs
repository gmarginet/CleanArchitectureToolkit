using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakFromLoopFlowState : ICatWorkflowState<BreakFromLoopFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakFromLoopFlow : ICatWorkflow<BreakFromLoopFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakFromLoopFlowState> builder)
    {
        builder.While(s => s.Number < 10, w =>
        {
            w.Run(s => s.Number++);
            w.If(s => s.Number == 2, t => t.BreakFromLoop());
            w.Run(s => s.Trace.Add("i"));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
