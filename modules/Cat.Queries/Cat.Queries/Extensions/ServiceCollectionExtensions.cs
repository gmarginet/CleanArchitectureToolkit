using System;
using Cat.Decorators.Extensions;
using Cat.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Queries.Extensions;

/// <summary>
/// Registration helpers for the queries module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the query processor and every query handler found in the given assemblies.
    /// Handlers get a scoped lifetime. Open generic handlers are skipped.
    /// Registers the decorators module too, unless it is already registered.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for handlers.</param>
    public static void AddCatQueriesModule(this IServiceCollection services,
        params Type[] types)
    {
        services.AddCatDecoratorsModule();

        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatQueryHandler<,>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        services.AddScoped<ICatQueryProcessor, CatQueryProcessor>();
    }
}