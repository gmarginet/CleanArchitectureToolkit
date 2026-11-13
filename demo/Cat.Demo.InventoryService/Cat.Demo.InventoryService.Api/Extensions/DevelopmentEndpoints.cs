using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Cat.Demo.InventoryService.Api.Extensions;

/// <summary>
/// Endpoints that let you try out the service without the real triggers.
/// Map them in <c>Development</c> only. Each background worker gets its own group.
/// </summary>
public static class DevelopmentEndpoints
{
    /// <summary>
    /// The OpenAPI group name of the development endpoints. It is the same name the event processor uses, so all development endpoints
    /// are in one document. They are not in the default OpenAPI document, so no generated client gets them.
    /// </summary>
    public const string DevDocumentName = "dev";

    public static IEndpointRouteBuilder MapInventoryServiceDevelopmentEndpoints(this IEndpointRouteBuilder builder)
    {
        var developmentGroup = builder.MapGroup("/development").WithGroupName(DevDocumentName);

        // Simulates the scheduler. The scheduler runs this request every night. This endpoint stays, so a developer
        // can try the request at once, without the scheduler and without waiting for the schedule.
        var schedulerGroup = developmentGroup.MapGroup("/scheduler");
        schedulerGroup.MapCatPost<LowStockReportRequest>("/low-stock-report", CatResponseType.NoContent)
            .WithName("LowStockReport");

        return builder;
    }
}
