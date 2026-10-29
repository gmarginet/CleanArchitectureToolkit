using System;
using Cat.Commands.Abstractions;
using Cat.Decorators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Commands.Extensions;

/// <summary>
/// Registration helpers for the commands module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the command processor and every command handler found in the given assemblies.
    /// Handlers get a scoped lifetime. Open generic handlers are skipped.
    /// Registers the decorators module too, unless it is already registered.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for handlers.</param>
    public static void AddCatCommandsModule(this IServiceCollection services,
        params Type[] types)
    {
        services.AddCatDecoratorsModule();

        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatCommandHandler<>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        services.AddScoped<ICatCommandProcessor, CatCommandProcessor>();
    }
}