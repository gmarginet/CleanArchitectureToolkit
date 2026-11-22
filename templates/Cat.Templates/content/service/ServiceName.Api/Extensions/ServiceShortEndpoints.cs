using Cat.Minimal.Api;
using Cat.Responses.Abstractions;
#if (ExampleRequest)
using ServiceName.Contracts.Models;
using ServiceName.Contracts.ServiceRequests;
#endif

namespace ServiceName.Api.Extensions;

public static class ServiceShortEndpoints
{
    public static IEndpointRouteBuilder MapServiceShortEndpoints(this IEndpointRouteBuilder builder)
    {
        var serviceBuilder = builder.MapGroup("/servicelower");
#if (ExampleRequest)

        serviceBuilder.MapCatGet<ExampleGetRequest, ExampleModel>("/examples/{exampleId:guid}", CatResponseType.Ok, CatResponseType.NotFound)
            .WithName("GetExample");
#endif

        return builder;
    }
}
