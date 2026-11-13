using Cat.Scheduling.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Scheduling.EFCore.Extensions;

/// <summary>
/// Registration helpers for the EF Core claim store.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the claim store on the given context. It replaces the store in memory.
    /// The context must call <see cref="ModelBuilderExtensions.AddCatScheduling"/> in <c>OnModelCreating</c>.
    /// </summary>
    /// <typeparam name="TDbContext">The context of the service that holds the job run table.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatSchedulingEFCore<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.RemoveAll<ICatJobClaimStore>();
        services.AddSingleton<ICatJobClaimStore, EfCoreJobClaimStore<TDbContext>>();
        return services;
    }
}
