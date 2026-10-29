using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeSetAndLogSnippetsState : ICatWorkflowState<ReadmeSetAndLogSnippetsState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
    public int Attempts { get; set; }
    public string Status { get; set; } = "New";
}

public class ReadmeSetAndLogSnippets : ICatWorkflow<ReadmeSetAndLogSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeSetAndLogSnippetsState> builder)
    {
        builder.Set(s => s.Total, s => s.Lines.Sum(l => l.Quantity * l.Price));
        builder.Set(s => s.Status, (logger, s) => s.Total > 0 ? "Priced" : "Empty");

        builder.LogInformation("Order total is {total}", s => [s.Total]);
        builder.Log(LogLevel.Warning, "Order has {attempts} attempts", s => [s.Attempts]);
    }
}
