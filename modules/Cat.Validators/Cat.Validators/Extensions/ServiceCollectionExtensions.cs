using System;
using Cat.Validators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Validators.Extensions;

/// <summary>
/// Registration helpers for the validators module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the validator processor and every validator found in the given assemblies.
    /// Validators get a scoped lifetime. Open generic validators are skipped.
    /// The module also needs the compiled member expression cache from Cat.Expressions.
    /// </summary>
    /// <param name="collection">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for validators.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatValidatorsModule(this IServiceCollection collection,
        params Type[] types)
    {
        collection.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatValidator<>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        collection.AddScoped<ICatValidatorProcessor, CatValidatorProcessor>();
        return collection;
    }
}
