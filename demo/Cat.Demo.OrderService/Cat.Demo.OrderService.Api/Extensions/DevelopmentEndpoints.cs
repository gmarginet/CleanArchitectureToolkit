using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.OrderService.Api.Extensions;

/// <summary>
/// Endpoints that let you try out the service without the real triggers.
/// Map them in <c>Development</c> only. Each background worker gets its own group.
/// </summary>
public static class DevelopmentEndpoints
{
    /// <summary>
    /// The OpenAPI group name of the development endpoints. They are not in the default OpenAPI document, so no generated client gets them.
    /// Scalar shows them in a second document with this name.
    /// </summary>
    public const string DevDocumentName = "dev";

    public static IEndpointRouteBuilder MapOrderServiceDevelopmentEndpoints(this IEndpointRouteBuilder builder)
    {
        var developmentGroup = builder.MapGroup("/development").WithGroupName(DevDocumentName);

        // Simulates the scheduler. The scheduler runs these requests on a schedule. These endpoints stay, so a developer
        // can try a request at once, without the scheduler and without waiting for the schedule.
        var schedulerGroup = developmentGroup.MapGroup("/scheduler");
        schedulerGroup.MapCatPost<CleanUpOrderCountersRequest>("/clean-up-order-counters", CatResponseType.NoContent)
            .WithName("CleanUpOrderCounters");
        schedulerGroup.MapCatPost<CancelStuckOrdersRequest>("/cancel-stuck-orders", CatResponseType.NoContent)
            .WithName("CancelStuckOrders");

        return builder;
    }
}
