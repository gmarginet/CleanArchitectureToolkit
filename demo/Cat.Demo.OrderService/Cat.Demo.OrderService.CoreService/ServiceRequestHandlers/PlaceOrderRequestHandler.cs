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
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class PlaceOrderRequestHandler : ICatServiceRequestHandler<PlaceOrderRequest, OrderModel>
{
    private static readonly TimeSpan CancelCleanUpTimeout = TimeSpan.FromSeconds(10);

    private readonly ICatSagaRunner _sagaRunner;
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatEventAggregator _eventAggregator;
    private readonly ICatUser _currentUser;
    private readonly IUserEmail _userEmail;
    private readonly TimeProvider _timeProvider;

    public PlaceOrderRequestHandler(
        ICatSagaRunner sagaRunner,
        ICatQueryProcessor queryProcessor,
        ICatEventAggregator eventAggregator,
        ICatUser currentUser,
        IUserEmail userEmail,
        TimeProvider timeProvider)
    {
        _sagaRunner = sagaRunner;
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

        CatSagaResult sagaResult;
        try
        {
            sagaResult = await _sagaRunner.StartAsync<PlaceOrderWorkflow, PlaceOrderState>(state, cancellationToken: cancellationToken);
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

        if (sagaResult.Status == CatSagaStatus.Failed || sagaResult.Errors.Count > 0)
        {
            return CatResponse.BadRequest<OrderModel>([.. sagaResult.Errors]);
        }

        var orderResponse = await _queryProcessor.ProcessAsync(new OrderGetQuery(state.OrderId, _currentUser.GetOwnerFilter()), cancellationToken);
        var modelResponse = orderResponse.Cast<OrderModel>(x => x.ToModel());
        if (!modelResponse.IsSucceeded)
        {
            return modelResponse;
        }

        // The workflow waits for the payment, so the order is still Pending here. The caller asks for it again until the status changes.
        return sagaResult.Status == CatSagaStatus.Waiting
            ? CatResponse.Accepted(modelResponse.Value!)
            : CatResponse.Created(modelResponse.Value!);
    }
}
