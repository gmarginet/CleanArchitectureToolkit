using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record PaymentWorkflowState : ICatWorkflowState<PaymentWorkflowState>
{
    public decimal Amount { get; set; }
    public bool Paid { get; set; }
}

public class PaymentWorkflow : ICatWorkflow<PaymentWorkflowState>
{
    public void Build(ICatWorkflowBuilder<PaymentWorkflowState> builder)
    {
        builder.Run(s => s.Paid = s.Amount > 0);
    }
}
