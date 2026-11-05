using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.EventAggregators.Abstractions;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.Workflows.Steps;

/// <summary>Announces that the order is confirmed. The subscribers do the rest.</summary>
public class PublishOrderConfirmedStep : CatStepBodyAsync<PlaceOrderState>
{
    private readonly ICatEventAggregator _eventAggregator;

    public PublishOrderConfirmedStep(ICatEventAggregator eventAggregator, ILogger<PublishOrderConfirmedStep> logger)
        : base(logger)
    {
        _eventAggregator = eventAggregator;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        await _eventAggregator.PublishAsync(
            new OrderConfirmedEvent(WorkflowState.OrderId, WorkflowState.OrderNumber, WorkflowState.Total),
            cancellationToken);

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
