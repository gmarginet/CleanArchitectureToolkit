using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class PlaceOrderRequestHandler : ICatServiceRequestHandler<PlaceOrderRequest, OrderModel>
{
    private readonly ICatWorkflowProcessor _workflowProcessor;
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatUser _currentUser;
    private readonly IUserEmail _userEmail;
    private readonly TimeProvider _timeProvider;

    public PlaceOrderRequestHandler(
        ICatWorkflowProcessor workflowProcessor,
        ICatQueryProcessor queryProcessor,
        ICatUser currentUser,
        IUserEmail userEmail,
        TimeProvider timeProvider)
    {
        _workflowProcessor = workflowProcessor;
        _queryProcessor = queryProcessor;
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

        var workflowResponse = await _workflowProcessor.RunAsync<PlaceOrderWorkflow, PlaceOrderState>(state, cancellationToken);

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
