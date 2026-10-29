using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeIfSnippetsState : ICatWorkflowState<ReadmeIfSnippetsState>
{
    public OrderType Type { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public string Status { get; set; } = "New";
}

public class ReadmeIfSnippets : ICatWorkflow<ReadmeIfSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeIfSnippetsState> builder)
    {
        builder.If(s => s.Type == OrderType.Express,
            then =>
            {
                then.Set(s => s.Status, s => "Express");
                then.LogInformation("Express order", s => []);
            },
            otherwise =>
            {
                otherwise.Set(s => s.Status, s => "Standard");
            });

        builder.If(s => s.Total >= 100, then => then.Set(s => s.Discount, s => s.Total * 0.1m));
    }
}
