using Cat.ServiceRequests.Abstractions;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

namespace Cat.ServiceRequests.Minimal.Api;

/// <summary>
/// A service request that carries a JSON Patch document and the route values that identify the resource to patch.
/// </summary>
/// <typeparam name="TRouteParameters">The type that holds the route and query values, such as the id of the resource.</typeparam>
/// <typeparam name="TModel">The model the patch operations apply to.</typeparam>
/// <param name="RouteParameters">The route and query values that identify the resource to patch.</param>
/// <param name="PatchDocument">The patch operations to apply to the model.</param>
public record PatchDocumentRequest<TRouteParameters, TModel>(TRouteParameters RouteParameters, JsonPatchDocument<TModel> PatchDocument)
    : ICatServiceRequest where TModel : class;
