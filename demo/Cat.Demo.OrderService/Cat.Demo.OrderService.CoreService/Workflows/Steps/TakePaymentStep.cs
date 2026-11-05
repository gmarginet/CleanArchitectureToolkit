using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.Workflows.Steps;

/// <summary>
/// Takes the payment. It never fails the workflow.
/// It writes the answer to the state, and an <c>If</c> in the workflow decides what to do with it.
/// </summary>
public class TakePaymentStep : CatStepBodyAsync<PlaceOrderState>
{
    private readonly IPaymentProvider _paymentProvider;

    public TakePaymentStep(IPaymentProvider paymentProvider, ILogger<TakePaymentStep> logger)
        : base(logger)
    {
        _paymentProvider = paymentProvider;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var result = await _paymentProvider.TakePaymentAsync(WorkflowState.OrderNumber, WorkflowState.Total, cancellationToken);

        WorkflowState.PaymentApproved = result.Approved;
        WorkflowState.PaymentReference = result.Reference;

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
