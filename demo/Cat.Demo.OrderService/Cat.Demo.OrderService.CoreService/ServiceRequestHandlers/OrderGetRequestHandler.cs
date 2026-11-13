using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class OrderGetRequestHandler : ICatServiceRequestHandler<OrderGetRequest, OrderModel>
{
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICatUser _currentUser;

    public OrderGetRequestHandler(ICatQueryProcessor queryProcessor, ICatUser currentUser)
    {
        _queryProcessor = queryProcessor;
        _currentUser = currentUser;
    }

    public async Task<ICatResponse<OrderModel>> HandleAsync(OrderGetRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!_currentUser.IsAuthenticated)
        {
            return CatResponse.Unauthorized<OrderModel>(OrderErrorDefinitions.NotAuthenticated.CreateCatError());
        }

        // The owner filter makes the orders of other customers come back as not found.
        var response = await _queryProcessor.ProcessAsync(new OrderGetQuery(serviceRequest.OrderId, _currentUser.GetOwnerFilter()), cancellationToken);
        return response.Cast<OrderModel>(x => x.ToModel());
    }
}
