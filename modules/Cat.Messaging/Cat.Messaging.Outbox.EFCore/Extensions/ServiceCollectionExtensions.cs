using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Messaging.Outbox.EFCore.Extensions;

/// <summary>
/// Registration helpers for the EF Core outbox.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the EF Core outbox store on the given context.
    /// The context must call <see cref="ModelBuilderExtensions.AddCatOutbox"/> in <c>OnModelCreating</c>.
    /// </summary>
    /// <typeparam name="TDbContext">The context of the service that holds the outbox table.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatMessagingOutboxEfCore<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddScoped<ICatOutboxStore, EfCoreOutboxStore<TDbContext>>();
        return services;
    }
}
