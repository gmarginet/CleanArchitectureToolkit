using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cat.Inbox.AspNetCore.Extensions;

/// <summary>
/// Adds the inbox to an endpoint, so a call that was handled before is skipped.
/// </summary>
public static class EndpointConventionBuilderExtensions
{
    /// <summary>
    /// Skips a call whose id was handled before. The id is the value of a header, such as <c>webhook-id</c>.
    /// </summary>
    /// <remarks>
    /// The filter adds a row to the <c>DbContext</c> of the request scope, and the endpoint saves it with its own <c>SaveChanges</c>.
    /// A call that fails saves nothing. A call without the header is handled without the inbox, and the filter logs a warning.
    /// Check the signature of a webhook before this filter, with the SDK of the provider.
    /// </remarks>
    /// <typeparam name="TBuilder">The type of the endpoint builder.</typeparam>
    /// <param name="builder">The endpoint builder.</param>
    /// <param name="header">The name of the header with the id of the call.</param>
    /// <param name="repeatStatusCode">The status that a repeated call gets. The body is empty.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static TBuilder WithCatInbox<TBuilder>(this TBuilder builder, string header, int repeatStatusCode = StatusCodes.Status200OK)
        where TBuilder : IEndpointConventionBuilder
    {
        if (string.IsNullOrWhiteSpace(header))
        {
            throw new ArgumentException("The name of the header is required.", nameof(header));
        }

        builder.AddEndpointFilter((context, next) => CatInboxEndpointFilter.InvokeAsync(
            context, next, ctx => ctx.HttpContext.Request.Headers[header].ToString(), $"the header {header}", repeatStatusCode));
        return builder;
    }

    /// <summary>
    /// Skips a call whose id was handled before. The id comes from an argument the endpoint already bound, such as the body.
    /// </summary>
    /// <remarks>
    /// Use it for a provider that sends the id in the body. The filter finds the argument by its type, so the endpoint
    /// must have exactly one argument of that type. See the overload with a header for the rest of the rules.
    /// </remarks>
    /// <typeparam name="TBuilder">The type of the endpoint builder.</typeparam>
    /// <typeparam name="TArgument">The type of the bound argument that holds the id.</typeparam>
    /// <param name="builder">The endpoint builder.</param>
    /// <param name="idSelector">Reads the id from the argument.</param>
    /// <param name="repeatStatusCode">The status that a repeated call gets. The body is empty.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static TBuilder WithCatInbox<TBuilder, TArgument>(this TBuilder builder, Func<TArgument, string?> idSelector,
        int repeatStatusCode = StatusCodes.Status200OK)
        where TBuilder : IEndpointConventionBuilder
    {
        if (idSelector == null)
        {
            throw new ArgumentNullException(nameof(idSelector));
        }

        builder.AddEndpointFilter((context, next) => CatInboxEndpointFilter.InvokeAsync(
            context, next,
            ctx =>
            {
                var argument = ctx.Arguments.OfType<TArgument>().FirstOrDefault();
                return argument == null ? null : idSelector(argument);
            },
            $"the argument {typeof(TArgument).Name}", repeatStatusCode));
        return builder;
    }
}