using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ProcessOrderWorkflowState : ICatWorkflowState<ProcessOrderWorkflowState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public string Status { get; set; } = "New";
}

public class ProcessOrderWorkflow : ICatWorkflow<ProcessOrderWorkflowState>
{
    public void Build(ICatWorkflowBuilder<ProcessOrderWorkflowState> builder)
    {
        builder.Set(s => s.Total, s => s.Lines.Sum(l => l.Quantity * l.Price));

        builder.If(s => s.Total >= 100,
            then => then.Set(s => s.Discount, s => s.Total * 0.1m));

        builder.Run(s => s.Status = "Processed");
    }
}
