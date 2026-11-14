using Cat.Sagas.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Sagas.EFCore.Extensions;

/// <summary>
/// Registration helpers for the EF Core saga store.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the saga store on the given context. It replaces the store in memory.
    /// The context must call <see cref="ModelBuilderExtensions.AddCatSagas"/> in <c>OnModelCreating</c>.
    /// </summary>
    /// <typeparam name="TDbContext">The context of the service that holds the saga table.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatSagasEFCore<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.RemoveAll<ICatSagaStore>();
        services.AddScoped<ICatSagaStore, EfCoreSagaStore<TDbContext>>();
        return services;
    }
}
