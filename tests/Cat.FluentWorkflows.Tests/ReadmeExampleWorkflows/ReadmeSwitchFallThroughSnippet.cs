using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeSwitchFallThroughSnippetState : ICatWorkflowState<ReadmeSwitchFallThroughSnippetState>
{
    public OrderType Type { get; set; }
    public string Status { get; set; } = "New";
}

public class ReadmeSwitchFallThroughSnippet : ICatWorkflow<ReadmeSwitchFallThroughSnippetState>
{
    public void Build(ICatWorkflowBuilder<ReadmeSwitchFallThroughSnippetState> builder)
    {
        builder.Switch(s => s.Type, cases =>
        {
            cases.Case(OrderType.Express);
            cases.Case(OrderType.Pickup, steps => steps.Set(s => s.Status, s => "Fast lane"));
        });
    }
}
