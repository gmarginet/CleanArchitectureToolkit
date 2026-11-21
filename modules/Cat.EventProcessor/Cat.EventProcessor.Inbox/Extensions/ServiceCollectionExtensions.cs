using Cat.EventProcessor.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Inbox.Extensions;

/// <summary>
/// Registration helpers for the inbox of the event processor.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Lets the receiver use the inbox of <c>Cat.Inbox</c> for the message types that have <c>UseInbox</c> on.
    /// An <c>ICatInboxStore</c> must be registered too, such as <c>AddCatInboxEfCore</c> of <c>Cat.Inbox.EFCore</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatEventProcessorInbox(this IServiceCollection services)
    {
        services.AddScoped<ICatHandledMessages, InboxHandledMessages>();
        return services;
    }
}