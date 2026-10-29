using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record WhileFlowState : ICatWorkflowState<WhileFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class WhileFlow : ICatWorkflow<WhileFlowState>
{
    public void Build(ICatWorkflowBuilder<WhileFlowState> builder)
    {
        builder.While(s => s.Number < 3, w =>
        {
            w.Run(s => s.Number++);
            w.Run(s => s.Trace.Add("i"));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}
