using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeSwitchSnippetsState : ICatWorkflowState<ReadmeSwitchSnippetsState>
{
    public OrderType Type { get; set; }
    public string Status { get; set; } = "New";
}

public class ReadmeSwitchSnippets : ICatWorkflow<ReadmeSwitchSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeSwitchSnippetsState> builder)
    {
        builder.Switch(s => s.Type, cases =>
        {
            cases.Case(OrderType.Standard, steps => steps.Set(s => s.Status, s => "Standard"));
            cases.Case(OrderType.Express, steps => steps.Set(s => s.Status, s => "Express"));
            cases.Default(steps => steps.Set(s => s.Status, s => "Other"));
        });
    }
}
