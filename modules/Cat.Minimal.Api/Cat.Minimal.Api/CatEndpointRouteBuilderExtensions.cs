using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;
using Cat.Responses.Abstractions.Extensions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Cat.Minimal.Api;

/// <summary>
/// Maps service requests to minimal API endpoints.
/// </summary>
public static class CatEndpointRouteBuilderExtensions
{
    //TODO GMA: Refactor to basic rest api operations like in GD projects
    /// <summary>
    /// Maps a POST endpoint that runs a service request without a payload.
    /// A succeeded response gives 200 with no body. A failed response gives <see cref="CatProblemDetails"/>
    /// with status 400, 404, 401 or 500, depending on the response type.
    /// An empty body gives a 400, unless the request type has a parameterless constructor.
    /// </summary>
    /// <typeparam name="TRequest">The service request. The JSON body is read into it.</typeparam>
    /// <param name="builder">The route builder, or a group.</param>
    /// <param name="pattern">The route pattern, like <c>/create-update</c>.</param>
    public static void MapCatServiceRequest<TRequest>(
        this IEndpointRouteBuilder builder,
        string pattern)
        where TRequest : class, ICatServiceRequest
    {
        builder.MapPost(pattern, async Task<Results<Ok, ProblemHttpResult>> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor, 
                [FromServices] ILogger<object> logger,
                [FromBody] TRequest? request,
                HttpContext httpContext,
                CancellationToken cancellationToken) =>
            {
                if (TryGetRequest(request, out var serviceRequest) is false) return CreateMissingBodyProblem(httpContext);

                var response = await serviceRequestProcessor.ProcessAsync(serviceRequest, cancellationToken);

                if (response.IsSucceeded) return TypedResults.Ok();

                return CreateFailedResponseProblem<TRequest>(response, logger, httpContext);
            })
            .Accepts<TRequest>(MediaTypeNames.Application.Json)
            .Produces(StatusCodes.Status200OK)
            .Produces<CatProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<CatProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<CatProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<CatProblemDetails>(StatusCodes.Status500InternalServerError);
    }
    
    /// <summary>
    /// Maps a POST endpoint that runs a service request with a payload.
    /// A succeeded response gives 200 with the payload as JSON. A failed response gives <see cref="CatProblemDetails"/>
    /// with status 400, 404, 401 or 500, depending on the response type.
    /// An empty body gives a 400, unless the request type has a parameterless constructor.
    /// </summary>
    /// <typeparam name="TRequest">The service request. The JSON body is read into it.</typeparam>
    /// <typeparam name="TResponse">The type of the payload.</typeparam>
    /// <param name="builder">The route builder, or a group.</param>
    /// <param name="pattern">The route pattern, like <c>/get</c>.</param>
    public static void MapCatServiceRequest<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern)
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        builder.MapPost(pattern, async Task<Results<Ok<TResponse>, ProblemHttpResult>> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [FromServices] ILogger<object> logger,
                [FromBody] TRequest? request,
                HttpContext httpContext,
                CancellationToken cancellationToken) =>
            {
                if (TryGetRequest(request, out var serviceRequest) is false) return CreateMissingBodyProblem(httpContext);

                var response = await serviceRequestProcessor.ProcessAsync(serviceRequest, cancellationToken);

                if (response.IsSucceeded) return TypedResults.Ok(response.Value);

                return CreateFailedResponseProblem<TRequest>(response, logger, httpContext);
            })
            .Accepts<TRequest>(MediaTypeNames.Application.Json)
            .Produces<TResponse>()
            .Produces<CatProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<CatProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<CatProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<CatProblemDetails>(StatusCodes.Status500InternalServerError);
    }

    /// <summary>
    /// Uses the request from the body. An empty body falls back to the parameterless constructor.
    /// </summary>
    /// <returns><c>false</c> when the body is empty and the request type has no parameterless constructor.</returns>
    private static bool TryGetRequest<TRequest>(TRequest? body, out TRequest request)
        where TRequest : class
    {
        if (body is not null)
        {
            request = body;
            return true;
        }

        if (typeof(TRequest).GetConstructor(Type.EmptyTypes) is not null)
        {
            request = Activator.CreateInstance<TRequest>();
            return true;
        }

        request = null!;
        return false;
    }

    /// <summary>
    /// Creates the 400 answer for an empty body that can't be turned into a request.
    /// </summary>
    private static ProblemHttpResult CreateMissingBodyProblem(HttpContext httpContext)
    {
        var problemDetails = new CatProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "A bad request was made.",
            Detail = "The request body is required.",
            Instance = httpContext.Request.Path.ToString(),
            CatErrors = [],
            CatTraceId = Activity.Current?.Id ?? httpContext.TraceIdentifier
        };

        return TypedResults.Problem(problemDetails);
    }

    /// <summary>
    /// Logs the errors of a failed response and creates the problem details answer for it.
    /// </summary>
    private static ProblemHttpResult CreateFailedResponseProblem<TRequest>(ICatResponse response, ILogger logger, HttpContext httpContext)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        logger.LogCatResponseErrors(response, "Error occurred during handling of ServiceRequest {requestName} (catTraceId: {catTraceId}):", typeof(TRequest).Name, traceId);

        var problemDetails = new CatProblemDetails(
            catResponse: response,
            instance: httpContext.Request.Path.ToString(),
            catTraceId: traceId);

        return TypedResults.Problem(problemDetails);
    }
}