using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.InventoryService.Api.Extensions;

public static class InventoryEndpoints
{
    public static IEndpointRouteBuilder MapInventoryServiceEndpoints(this IEndpointRouteBuilder builder, bool requireLogin = false)
    {
        var inventoryBuilder = builder.MapGroup("/inventory");

        if (requireLogin)
        {
            inventoryBuilder.RequireAuthorization();
        }

        var reservationsBuilder = inventoryBuilder.MapGroup("/reservations");

        reservationsBuilder.MapCatPost<StockReserveRequest>("/", CatResponseType.Ok, CatResponseType.NotFound, CatResponseType.Conflict, CatResponseType.Unauthorized)
            .WithName("ReserveStock");
        reservationsBuilder.MapCatDelete<StockReleaseRequest>("/{orderNumber}", CatResponseType.Ok, CatResponseType.Unauthorized)
            .WithName("ReleaseStock");

        return builder;
    }
}
