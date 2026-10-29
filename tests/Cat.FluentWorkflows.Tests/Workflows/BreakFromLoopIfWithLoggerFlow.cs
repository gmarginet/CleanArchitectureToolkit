using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakFromLoopIfWithLoggerFlowState : ICatWorkflowState<BreakFromLoopIfWithLoggerFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakFromLoopIfWithLoggerFlow : ICatWorkflow<BreakFromLoopIfWithLoggerFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakFromLoopIfWithLoggerFlowState> builder)
    {
        builder.While(s => s.Number < 10, w =>
        {
            w.Run(s => s.Number++);
            w.BreakFromLoopIf((_, s) => s.Number == 3);
            w.Run(s => s.Trace.Add("i"));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
