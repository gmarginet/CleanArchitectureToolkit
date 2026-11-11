using Cat.Decorators.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Inbox.EFCore.Extensions;

/// <summary>
/// Registration helpers for the EF Core inbox.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the inbox store on the given context.
    /// The context must call <see cref="ModelBuilderExtensions.AddCatInbox"/> in <c>OnModelCreating</c>.
    /// Call <see cref="UseCatEventProcessorInbox"/> on the built service provider to switch the decorator on.
    /// </summary>
    /// <typeparam name="TDbContext">The context of the service that holds the inbox table.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatEventProcessorInbox<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.AddScoped<ICatInboxStore, EfCoreInboxStore<TDbContext>>();
        return services;
    }

    /// <summary>
    /// Adds the inbox decorator to the service request handlers. Call it on the built service provider, after <c>Build()</c>.
    /// </summary>
    /// <param name="serviceProvider">The built service provider.</param>
    public static void UseCatEventProcessorInbox(this IServiceProvider serviceProvider)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(InboxDecorator.CatServiceRequestHandler<>));
    }
}
