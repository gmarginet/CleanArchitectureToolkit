using Cat.Inbox.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Inbox.AspNetCore;

/// <summary>
/// The work of the filter that <c>WithCatInbox</c> adds to an endpoint.
/// </summary>
internal static class CatInboxEndpointFilter
{
    private const int MessageTypeMaxLength = 260;

    /// <summary>
    /// Skips the call when its id was handled before. Otherwise it adds a row for the id to the context of the request scope
    /// and runs the endpoint. The endpoint saves the row with its own <c>SaveChanges</c>.
    /// </summary>
    internal static async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next,
        Func<EndpointFilterInvocationContext, string?> readId,
        string idSource,
        int repeatStatusCode)
    {
        var http = context.HttpContext;
        var services = http.RequestServices;
        var logger = services.GetService<ILoggerFactory>()?.CreateLogger("Cat.Inbox.AspNetCore");
        var messageType = MessageTypeOf(http);

        var id = readId(context);
        if (string.IsNullOrWhiteSpace(id))
        {
            // A call without an id is handled without the inbox, as a bus message without an id is.
            logger?.LogWarning(
                "The call {Call} has no inbox id in {IdSource}, so it is handled without the inbox. Check the name of the header or the provider.",
                messageType, idSource);
            return await next(context);
        }

        var store = services.GetRequiredService<ICatInboxStore>();
        if (await store.ExistsAsync(id!, http.RequestAborted).ConfigureAwait(false))
        {
            return Results.StatusCode(repeatStatusCode);
        }

        store.Add(id!, messageType);
        var result = await next(context);

        if (!IsFailure(result) && !await store.ExistsAsync(id!, http.RequestAborted).ConfigureAwait(false))
        {
            logger?.LogError(
                "The call {Call} with the inbox id {InboxId} did not save its inbox row. The endpoint must save through the context of its own scope, such as with ICatCurrentScopeCommandProcessor, or a repeat of the call is not skipped.",
                messageType, id);
        }

        return result;
    }

    private static bool IsFailure(object? result) => result is IStatusCodeHttpResult { StatusCode: >= 400 };

    private static string MessageTypeOf(HttpContext http)
    {
        var route = (http.GetEndpoint() as RouteEndpoint)?.RoutePattern.RawText ?? http.Request.Path.Value ?? string.Empty;
        var text = $"{http.Request.Method} {route}";
        return text.Length <= MessageTypeMaxLength ? text : text.Substring(0, MessageTypeMaxLength);
    }
}