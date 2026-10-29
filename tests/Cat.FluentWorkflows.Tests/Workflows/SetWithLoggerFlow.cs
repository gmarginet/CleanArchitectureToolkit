using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SetWithLoggerFlowState : ICatWorkflowState<SetWithLoggerFlowState>
{
    public int Number { get; set; } = 4;
    public string Text { get; set; } = "";
}

public class SetWithLoggerFlow : ICatWorkflow<SetWithLoggerFlowState>
{
    public void Build(ICatWorkflowBuilder<SetWithLoggerFlowState> builder)
    {
        builder.Set(s => s.Text, (_, s) => "number " + s.Number);
    }
}
