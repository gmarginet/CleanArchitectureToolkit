using System;
using Cat.Decorators.Extensions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Extensions;

// ReSharper disable RedundantBoolCompare
/// <summary>
/// Registration helpers for the service requests module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the service request processor and every service request handler found in the given assemblies.
    /// Handlers get a scoped lifetime. Open generic handlers are skipped.
    /// Registers the decorators module too, unless it is already registered.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for handlers.</param>
    public static void AddCatServiceRequestsModule(this IServiceCollection services,
        params Type[] types)
    {
        services.AddCatDecoratorsModule();

        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatServiceRequestHandler<>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatServiceRequestHandler<,>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        services.AddScoped<ICatServiceRequestProcessor, CatServiceRequestProcessor>();
    }
}