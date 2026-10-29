using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record WhileBreakCascadeFlowState : ICatWorkflowState<WhileBreakCascadeFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class WhileBreakCascadeFlow : ICatWorkflow<WhileBreakCascadeFlowState>
{
    public void Build(ICatWorkflowBuilder<WhileBreakCascadeFlowState> builder)
    {
        builder.While(s => s.Number < 10, w =>
        {
            w.Run(s => s.Number++);
            w.BreakCascadeIf(s => s.Number == 2);
            w.Run(s => s.Trace.Add("i"));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
