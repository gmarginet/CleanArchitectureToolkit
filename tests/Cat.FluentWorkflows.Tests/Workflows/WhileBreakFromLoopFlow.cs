using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record WhileBreakFromLoopFlowState : ICatWorkflowState<WhileBreakFromLoopFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class WhileBreakFromLoopFlow : ICatWorkflow<WhileBreakFromLoopFlowState>
{
    public void Build(ICatWorkflowBuilder<WhileBreakFromLoopFlowState> builder)
    {
        builder.While(s => s.Number < 10, w =>
        {
            w.Run(s => s.Number++);
            w.BreakFromLoopIf(s => s.Number == 2);
            w.Run(s => s.Trace.Add("i"));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
