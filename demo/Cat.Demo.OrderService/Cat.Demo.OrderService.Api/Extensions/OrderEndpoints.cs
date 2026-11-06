using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.OrderService.Api.Extensions;

public static class OrderEndpoints
{
    public static IEndpointRouteBuilder MapOrderServiceEndpoints(this IEndpointRouteBuilder builder, bool requireLogin = false)
    {
        var ordersBuilder = builder.MapGroup("/orders");

        if (requireLogin)
        {
            ordersBuilder.RequireAuthorization();
        }

        ordersBuilder.MapCatPost<PlaceOrderRequest, OrderModel>("/", order => $"/orders/{order.Id}", CatResponseType.Created, CatResponseType.Unauthorized);
        ordersBuilder.MapCatGetList<OrderGetListRequest, OrderSummaryModel>("/", CatResponseType.Ok, CatResponseType.Unauthorized);
        ordersBuilder.MapCatGet<OrderGetRequest, OrderModel>("/{orderId:guid}", CatResponseType.Ok, CatResponseType.NotFound, CatResponseType.Unauthorized);
        ordersBuilder.MapCatPost<CancelOrderRequest>("/{orderId:guid}/cancel", CatResponseType.NoContent, CatResponseType.NotFound, CatResponseType.Conflict, CatResponseType.Unauthorized);

        return builder;
    }
}
