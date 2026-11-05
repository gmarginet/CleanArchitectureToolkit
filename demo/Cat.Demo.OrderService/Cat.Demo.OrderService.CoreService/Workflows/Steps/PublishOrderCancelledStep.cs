using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.Workflows.Steps;

/// <summary>Announces that the order is cancelled, with the reason from the state. The subscribers do the rest.</summary>
public class PublishOrderCancelledStep : CatStepBodyAsync<PlaceOrderState>
{
    private readonly ICatEventAggregator _eventAggregator;

    public PublishOrderCancelledStep(ICatEventAggregator eventAggregator, ILogger<PublishOrderCancelledStep> logger)
        : base(logger)
    {
        _eventAggregator = eventAggregator;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        await _eventAggregator.PublishAsync(
            new OrderCancelledEvent(WorkflowState.OrderId, WorkflowState.OrderNumber, WorkflowState.CancelReason),
            cancellationToken);

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
