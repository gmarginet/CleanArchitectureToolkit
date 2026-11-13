using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Events;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.EventAggregators.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class PlaceOrderRequestHandler : ICatServiceRequestHandler<PlaceOrderRequest, OrderModel>
{
    private static readonly TimeSpan CancelCleanUpTimeout = TimeSpan.FromSeconds(10);

    private readonly ICatWorkflowProcessor _workflowProcessor;
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatEventAggregator _eventAggregator;
    private readonly ICatUser _currentUser;
    private readonly IUserEmail _userEmail;
    private readonly TimeProvider _timeProvider;

    public PlaceOrderRequestHandler(
        ICatWorkflowProcessor workflowProcessor,
        ICatQueryProcessor queryProcessor,
        ICatEventAggregator eventAggregator,
        ICatUser currentUser,
        IUserEmail userEmail,
        TimeProvider timeProvider)
    {
        _workflowProcessor = workflowProcessor;
        _queryProcessor = queryProcessor;
        _eventAggregator = eventAggregator;
        _currentUser = currentUser;
        _userEmail = userEmail;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse<OrderModel>> HandleAsync(PlaceOrderRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!_currentUser.IsAuthenticated)
        {
            return CatResponse.Unauthorized<OrderModel>(OrderErrorDefinitions.NotAuthenticated.CreateCatError());
        }

        var state = new PlaceOrderState
        {
            PlacedAt = _timeProvider.GetUtcNow().UtcDateTime,
            CustomerExternalId = _currentUser.UserId,
            CustomerName = _currentUser.Name,
            CustomerEmail = _userEmail.Email,
            Lines = [.. serviceRequest.Order.Lines.Select(x => new PlaceOrderLineState { BookId = x.BookId, Quantity = x.Quantity })]
        };

        ICatWorkflowResponse workflowResponse;
        try
        {
            workflowResponse = await _workflowProcessor.RunAsync<PlaceOrderWorkflow, PlaceOrderState>(state, cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested && state.Created is not null)
        {
            // The caller gave up after the order was created, for example on a slow first call.
            // Nothing else would cancel the order, so it would stay Pending for good.
            // The request token is cancelled already, so the cancel event gets its own short lived token.
            using var cleanUp = new CancellationTokenSource(CancelCleanUpTimeout);
            await _eventAggregator.PublishAsync(
                new OrderCancelledEvent(state.OrderId, state.OrderNumber, OrderCancelReasons.RequestCancelled),
                cleanUp.Token);
            throw;
        }

        if (workflowResponse.ErrorList.Count > 0 || workflowResponse.WorkflowResult == CatStepExecutionResult.BreakCascade)
        {
            return CatResponse.BadRequest<OrderModel>([.. workflowResponse.ErrorList]);
        }

        var orderResponse = await _queryProcessor.ProcessAsync(new OrderGetQuery(state.OrderId, _currentUser.GetOwnerFilter()), cancellationToken);
        var modelResponse = orderResponse.Cast<OrderModel>(x => x.ToModel());

        return modelResponse.IsSucceeded
            ? CatResponse.Created(modelResponse.Value!)
            : modelResponse;
    }
}
