using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record CheckoutWorkflowState : ICatWorkflowState<CheckoutWorkflowState>, ICatHasSubWorkflowState<PaymentWorkflowState>
{
    public decimal Total { get; set; }
    public string Status { get; set; } = "New";
    public PaymentWorkflowState WorkflowState { get; set; } = new();
}

public class CheckoutWorkflow : ICatWorkflow<CheckoutWorkflowState>
{
    public void Build(ICatWorkflowBuilder<CheckoutWorkflowState> builder)
    {
        builder.Run(s => s.WorkflowState.Amount = s.Total);
        builder.Run<PaymentWorkflow, PaymentWorkflowState, CheckoutWorkflowState>();
        builder.Run(s => s.Status = s.WorkflowState.Paid ? "Paid" : "Unpaid");
    }
}
