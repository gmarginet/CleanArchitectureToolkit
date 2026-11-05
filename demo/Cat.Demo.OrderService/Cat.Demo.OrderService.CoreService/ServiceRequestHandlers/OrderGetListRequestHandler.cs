using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class OrderGetListRequestHandler : ICatServiceRequestHandler<OrderGetListRequest, IList<OrderSummaryModel>>
{
    private readonly ICatQueryProcessor _queryProcessor;
    private readonly ICurrentUser _currentUser;

    public OrderGetListRequestHandler(ICatQueryProcessor queryProcessor, ICurrentUser currentUser)
    {
        _queryProcessor = queryProcessor;
        _currentUser = currentUser;
    }

    public async Task<ICatResponse<IList<OrderSummaryModel>>> HandleAsync(OrderGetListRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!_currentUser.IsAuthenticated)
        {
            return CatResponse.Unauthorized<IList<OrderSummaryModel>>(OrderErrorDefinitions.NotAuthenticated.CreateCatError());
        }

        var response = await _queryProcessor.ProcessAsync(new OrderGetListQuery(_currentUser.GetOwnerFilter()), cancellationToken);
        return response.Cast<IList<OrderSummaryModel>>(x => [.. x.Select(y => y.ToSummaryModel())]);
    }
}
