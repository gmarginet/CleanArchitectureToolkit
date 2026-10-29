using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SetFlowState : ICatWorkflowState<SetFlowState>
{
    public int Number { get; set; }
    public string Name { get; set; } = "";
}

public class SetFlow : ICatWorkflow<SetFlowState>
{
    public void Build(ICatWorkflowBuilder<SetFlowState> builder)
    {
        builder.Set(s => s.Number, _ => 42);
        builder.Set(s => s.Name, (_, s) => "n=" + s.Number);
    }
}
