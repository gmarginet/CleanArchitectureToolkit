using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Minimal.Api.Extensions;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Minimal.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Cat.Minimal.Api;

/// <summary>
/// Maps a <see cref="ICatServiceRequest"/> to a minimal API endpoint for each http method.
/// </summary>
/// <remarks>
/// <para>
/// You choose which <see cref="CatResponseType"/> values the service request handler returns. The OpenAPI document
/// lists exactly those status codes, so the consumers of your api see what the endpoint really does.
/// </para>
/// <para>
/// Leave the response types out and the endpoint uses the default for its http method:
/// <see cref="CatResponseType.Ok"/> for GET, <see cref="CatResponseType.Created"/> for POST and
/// <see cref="CatResponseType.NoContent"/> for PUT, PATCH and DELETE.
/// </para>
/// <para>
/// Some status codes can always happen, so every endpoint lists them whatever you pass:
/// </para>
/// <list type="bullet">
/// <item><description>400, because the request can fail to bind. Think of malformed json or a route value that doesn't parse.</description></item>
/// <item><description>500, because an unexpected exception can always occur.</description></item>
/// <item><description>415, only for endpoints that read a body, because the content type can be wrong.</description></item>
/// </list>
/// <para>
/// The endpoint checks the response type at runtime. A handler that returns a type the endpoint doesn't list causes an
/// <see cref="InvalidOperationException"/>, so the documentation and the real behavior can't drift apart unnoticed.
/// </para>
/// <para>
/// Every method returns the <see cref="RouteHandlerBuilder"/>, so you can chain calls such as
/// <c>WithName</c> and <c>RequireAuthorization</c>.
/// </para>
/// </remarks>
public static class CatEndpointRouteBuilderExtensions
{
    // The handler delegates return IResult, not a Results union type. A Results return type adds every type in the
    // union to the OpenAPI document, whatever you pass to Produces. IResult adds nothing, so the metadata comes
    // from the response types only.
    private const string JsonContentType = "application/json";
    private const string JsonPatchContentType = "application/json-patch+json";
    private const string ProblemJsonContentType = "application/problem+json";

    private static readonly CatResponseType[] DefaultsForGetMethods = [CatResponseType.Ok];
    private static readonly CatResponseType[] DefaultsForPutMethods = [CatResponseType.NoContent];
    private static readonly CatResponseType[] DefaultsForPatchMethods = [CatResponseType.NoContent];
    private static readonly CatResponseType[] DefaultsForPostMethods = [CatResponseType.Created];
    private static readonly CatResponseType[] DefaultsForDeleteMethods = [CatResponseType.NoContent];

    private static readonly CatResponseType[] AlwaysPossible = [CatResponseType.BadRequest, CatResponseType.InternalServerError];

    /// <summary>
    /// Maps a GET endpoint that returns the value of the service request.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Its properties bind from the route, the query string and the headers.</typeparam>
    /// <typeparam name="TResponse">The type of the value in the response body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Ok"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatGet<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForGetMethods);

        return builder.MapGet(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "GET",
                    ok: () => TypedResults.Ok(response.Value));
            })
            .ProducesCatResponseTypes(allowed,okValueType: typeof(TResponse));
    }

    /// <summary>
    /// Maps a GET endpoint that returns a list of items.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Its properties bind from the route, the query string and the headers.</typeparam>
    /// <typeparam name="TResponse">The type of the items in the list.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Ok"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatGetList<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest<IList<TResponse>>
        => builder.MapCatGet<TRequest, IList<TResponse>>(pattern, responseTypes);

    /// <summary>
    /// Maps a GET endpoint that returns one page of a larger list.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Its properties bind from the route, the query string and the headers.</typeparam>
    /// <typeparam name="TResponse">The type of the items in the page.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Ok"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatGetPagedList<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest<ICatPagedList<TResponse>>
        => builder.MapCatGet<TRequest, ICatPagedList<TResponse>>(pattern, responseTypes);

    /// <summary>
    /// Maps a PUT endpoint that replaces a resource.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Give a property <c>[FromBody]</c> to read the request body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.NoContent"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPut<TRequest>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForPutMethods);

        return builder.MapPut(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "PUT");
            })
            .ProducesCatResponseTypes(allowed);
    }

    /// <summary>
    /// Maps a PATCH endpoint that changes part of a resource. The request body holds your own change model.
    /// Use <see cref="MapCatPatchDocument{TRouteParameters,TModel}"/> to accept a JSON Patch document instead.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Give a property <c>[FromBody]</c> to read the request body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.NoContent"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPatch<TRequest>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForPatchMethods);

        return builder.MapPatch(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "PATCH");
            })
            .ProducesCatResponseTypes(allowed);
    }

    /// <summary>
    /// Maps a PATCH endpoint that accepts a JSON Patch document (<c>application/json-patch+json</c>).
    /// The service request handler receives a <see cref="PatchDocumentRequest{TRouteParameters,TModel}"/>.
    /// A request without a patch document gets a 400.
    /// </summary>
    /// <typeparam name="TRouteParameters">The type that binds the route and query values, such as the id of the resource.</typeparam>
    /// <typeparam name="TModel">The model the patch operations apply to. It doesn't have to be a service request.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.NoContent"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPatchDocument<TRouteParameters, TModel>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TModel : class
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForPatchMethods);
        var requestType = typeof(PatchDocumentRequest<TRouteParameters, TModel>);

        return builder.MapPatch(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRouteParameters routeParameters,
                [FromBody] JsonPatchDocument<TModel>? patchDocument,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                // The body is optional for the framework, so an empty body ends up here as null.
                if (patchDocument is null) return TypedResults.Problem(CatProblemDetails.Create(
                    httpContext,
                    StatusCodes.Status400BadRequest,
                    CatResponseType.BadRequest.ToTitle(),
                    "The request has no patch document in its body."));

                var patchDocumentRequest = new PatchDocumentRequest<TRouteParameters, TModel>(routeParameters, patchDocument);
                var response = await serviceRequestProcessor.ProcessAsync(patchDocumentRequest, ct);

                return response.ToHttpResult(httpContext, allowed, requestType, "PATCH");
            })
            .Accepts<JsonPatchDocument<TModel>>(JsonPatchContentType)
            .ProducesCatResponseTypes(allowed);
    }

    /// <summary>
    /// Maps a POST endpoint that creates a resource. A <see cref="CatResponseType.Created"/> response has no body
    /// and no Location header.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Give a property <c>[FromBody]</c> to read the request body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Created"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPost<TRequest>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForPostMethods);

        return builder.MapPost(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "POST");
            })
            .ProducesCatResponseTypes(allowed);
    }

    /// <summary>
    /// Maps a POST endpoint that creates a resource and returns it. A <see cref="CatResponseType.Created"/> response
    /// carries the created value in its body and has no Location header.
    /// Use the overload with a <c>location</c> argument to add the header.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Give a property <c>[FromBody]</c> to read the request body.</typeparam>
    /// <typeparam name="TResponse">The type of the created value in the response body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Created"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPost<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest<TResponse>
        => builder.MapCatPost<TRequest, TResponse>(pattern, null, responseTypes);

    /// <summary>
    /// Maps a POST endpoint that creates a resource and returns it. A <see cref="CatResponseType.Created"/> response
    /// carries the created value in its body and a Location header built by <paramref name="location"/>.
    /// An <see cref="CatResponseType.Accepted"/> response carries the value and the header the same way, for work that is not finished yet.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Give a property <c>[FromBody]</c> to read the request body.</typeparam>
    /// <typeparam name="TResponse">The type of the created value in the response body.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="location">
    /// Builds the Location header from the created value, for example <c>todo => $"/todo/{todo.Id}"</c>.
    /// The response has no Location header when this is <c>null</c> or returns <c>null</c>.
    /// </param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.Created"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatPost<TRequest, TResponse>(
        this IEndpointRouteBuilder builder,
        string pattern,
        Func<TResponse, string?>? location,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForPostMethods);

        return builder.MapPost(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "POST",
                    created: () => TypedResults.Created(location?.Invoke(response.Value), response.Value),
                    accepted: () => TypedResults.Accepted(location?.Invoke(response.Value), response.Value));
            })
            .ProducesCatResponseTypes(allowed, createdValueType: typeof(TResponse), acceptedValueType: typeof(TResponse));
    }

    /// <summary>
    /// Maps a DELETE endpoint that removes a resource.
    /// </summary>
    /// <typeparam name="TRequest">The service request. Its properties bind from the route, the query string and the headers.</typeparam>
    /// <param name="builder">The route builder to add the endpoint to.</param>
    /// <param name="pattern">The route pattern of the endpoint.</param>
    /// <param name="responseTypes">The response types the handler returns. Defaults to <see cref="CatResponseType.NoContent"/>.</param>
    /// <returns>The builder of the endpoint, to chain more calls.</returns>
    public static RouteHandlerBuilder MapCatDelete<TRequest>(
        this IEndpointRouteBuilder builder,
        string pattern,
        params CatResponseType[] responseTypes)
        where TRequest : class, ICatServiceRequest
    {
        var allowed = ResolveResponseTypes(responseTypes, DefaultsForDeleteMethods);

        return builder.MapDelete(pattern, async Task<IResult> (
                [FromServices] ICatServiceRequestProcessor serviceRequestProcessor,
                [AsParameters] TRequest request,
                HttpContext httpContext,
                CancellationToken ct) =>
            {
                var response = await serviceRequestProcessor.ProcessAsync(request, ct);

                return response.ToHttpResult(httpContext, allowed, typeof(TRequest), "DELETE");
            })
            .ProducesCatResponseTypes(allowed);
    }

    /// <summary>
    /// Builds the list of response types an endpoint allows. Uses the defaults when no response types are given,
    /// adds the response types that can always happen and removes duplicates.
    /// </summary>
    /// <remarks>
    /// <see cref="CatResponseType"/> hands out a new instance on every call, so the types are compared, not the instances.
    /// </remarks>
    private static CatResponseType[] ResolveResponseTypes(
        CatResponseType[]? responseTypes,
        CatResponseType[] defaults)
    {
        return
        [
            .. (responseTypes is null || responseTypes.Length == 0 ? defaults : responseTypes)
                .Concat(AlwaysPossible)
                .DistinctBy(responseType => responseType.GetType())
        ];
    }

    /// <summary>
    /// Maps the response to an http result, but only when its type is one the endpoint allows.
    /// </summary>
    /// <param name="response">The response of the service request handler.</param>
    /// <param name="httpContext">The current request.</param>
    /// <param name="allowed">The response types the endpoint allows.</param>
    /// <param name="requestType">The type of the service request, used in the error message.</param>
    /// <param name="httpMethod">The http method of the endpoint, used in the error message.</param>
    /// <param name="ok">Builds the result for an Ok response with a body. Without it the result has no body.</param>
    /// <param name="created">Builds the result for a Created response with a body. Without it the result has no body.</param>
    /// <param name="accepted">Builds the result for an Accepted response with a body. Without it the result has no body.</param>
    /// <returns>The http result for the response.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response type isn't one the endpoint allows.</exception>
    private static IResult ToHttpResult(
        this ICatResponse response,
        HttpContext httpContext,
        CatResponseType[] allowed,
        Type requestType,
        string httpMethod,
        Func<IResult>? ok = null,
        Func<IResult>? created = null,
        Func<IResult>? accepted = null)
    {
        var responseType = response.Type.GetType();

        if (!allowed.Any(allowedType => allowedType.GetType() == responseType))
            throw new InvalidOperationException(
                $"The ServiceRequestHandler that handled the {requestType.FullName} request returned CatResponseType {responseType.Name}. " +
                $"This {httpMethod} endpoint only allows {string.Join(", ", allowed.Select(allowedType => allowedType.GetType().Name))}. " +
                $"Add {responseType.Name} to the responseTypes argument where the endpoint is mapped.");

        return response.Type switch
        {
            CatResponseType.Succeeded.Ok => ok?.Invoke() ?? TypedResults.Ok(),
            CatResponseType.Succeeded.Created => created?.Invoke() ?? TypedResults.Created(),
            CatResponseType.Succeeded.NoContent => TypedResults.NoContent(),
            CatResponseType.Succeeded.Accepted => accepted?.Invoke() ?? TypedResults.Accepted((string?)null),
            CatResponseType.Failed => TypedResults.Problem(response.ToProblemDetail(httpContext)),
            _ => throw new InvalidOperationException(
                $"CatResponseType {responseType.Name} is not supported in {httpMethod} http methods.")
        };
    }

    /// <summary>
    /// Adds one OpenAPI response per allowed response type, plus 415 when the endpoint reads a body.
    /// </summary>
    /// <param name="handlerBuilder">The endpoint to describe.</param>
    /// <param name="allowed">The response types the endpoint allows.</param>
    /// <param name="okValueType">The type of the body of an Ok response. <c>null</c> when it has no body.</param>
    /// <param name="createdValueType">The type of the body of a Created response. <c>null</c> when it has no body.</param>
    /// <param name="acceptedValueType">The type of the body of an Accepted response. <c>null</c> when it has no body.</param>
    /// <returns>The builder of the endpoint.</returns>
    private static RouteHandlerBuilder ProducesCatResponseTypes(
        this RouteHandlerBuilder handlerBuilder,
        CatResponseType[] allowed,
        Type? okValueType = null,
        Type? createdValueType = null,
        Type? acceptedValueType = null)
    {
        foreach (var responseType in allowed)
        {
            var statusCode = responseType.ToHttpStatusCode();

            switch (responseType)
            {
                case CatResponseType.Succeeded.Ok when okValueType is not null:
                    handlerBuilder.Produces(statusCode, okValueType, JsonContentType);
                    break;
                case CatResponseType.Succeeded.Created when createdValueType is not null:
                    handlerBuilder.Produces(statusCode, createdValueType, JsonContentType);
                    break;
                case CatResponseType.Succeeded.Accepted when acceptedValueType is not null:
                    handlerBuilder.Produces(statusCode, acceptedValueType, JsonContentType);
                    break;
                case CatResponseType.Succeeded:
                    handlerBuilder.Produces(statusCode);
                    break;
                case CatResponseType.Failed:
                    handlerBuilder.Produces<CatProblemDetails>(statusCode, ProblemJsonContentType);
                    break;
            }
        }

        // The framework adds IAcceptsMetadata when the endpoint reads a body, also when it inferred the body without a
        // [FromBody] attribute. Finally runs after that metadata is added, so it is the reliable place to check it.
        handlerBuilder.Finally(endpointBuilder =>
        {
            if (endpointBuilder.Metadata.OfType<IAcceptsMetadata>().Any())
                endpointBuilder.Metadata.Add(new ProducesResponseTypeMetadata(
                    StatusCodes.Status415UnsupportedMediaType, typeof(CatProblemDetails), [ProblemJsonContentType]));
        });

        return handlerBuilder;
    }
}
