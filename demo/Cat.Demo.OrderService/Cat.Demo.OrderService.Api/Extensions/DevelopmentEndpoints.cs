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
    public static IEndpointRouteBuilder MapOrderServiceDevelopmentEndpoints(this IEndpointRouteBuilder builder)
    {
        var developmentGroup = builder.MapGroup("/development");

        // Simulates the scheduler. The scheduler runs this request every night. This endpoint stays, so a developer
        // can try the request at once, without the scheduler and without waiting for the schedule.
        var schedulerGroup = developmentGroup.MapGroup("/scheduler");
        schedulerGroup.MapCatPost<CleanUpOrderCountersRequest>("/clean-up-order-counters", CatResponseType.NoContent)
            .WithName("CleanUpOrderCounters");

        return builder;
    }
}
