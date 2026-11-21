using System;
using System.Linq;
using Cat.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Cat.Resilience.Abstractions;

namespace Cat.Resilience.Queries.Extensions;

/// <summary>
/// Registration helpers for the retry around the query processor.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Retries the query types that you list, through a resilience profile, with a fresh scope for every try.
    /// Register the queries module with <c>AddCatQueriesModule</c> and the resilience module with <c>AddCatResilienceModule</c> first,
    /// because the processor is wrapped and the pipelines come from there.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Lists the query types, for example <c>options.Retry&lt;GetPriceQuery&gt;()</c>.</param>
    /// <returns>The same service collection, for chaining.</returns>
    /// <exception cref="InvalidOperationException">A query type is listed, but no <c>ICatQueryProcessor</c> is registered yet.</exception>
    public static IServiceCollection AddCatQueryRetry(this IServiceCollection services, Action<CatQueryRetryOptions> configure)
    {
        var options = new CatQueryRetryOptions();
        configure(options);

        var descriptor = services.LastOrDefault(registration => registration.ServiceType == typeof(ICatQueryProcessor) && !registration.IsKeyedService);
        if (descriptor == null)
        {
            if (options.HasRules)
            {
                throw new InvalidOperationException(
                    "A query type is listed for a retry, but no ICatQueryProcessor is registered. Call AddCatQueriesModule of Cat.Queries before AddCatQueryRetry.");
            }

            return services;
        }

        services.Remove(descriptor);
        services.Add(new ServiceDescriptor(typeof(ICatQueryProcessor),
            provider => new CatRetryQueryProcessor(CreateInner(provider, descriptor), provider.GetRequiredService<ICatResiliencePipelines>(), options),
            descriptor.Lifetime));
        return services;
    }

    private static ICatQueryProcessor CreateInner(IServiceProvider provider, ServiceDescriptor descriptor)
    {
        if (descriptor.ImplementationInstance != null)
        {
            return (ICatQueryProcessor)descriptor.ImplementationInstance;
        }

        if (descriptor.ImplementationFactory != null)
        {
            return (ICatQueryProcessor)descriptor.ImplementationFactory(provider);
        }

        return (ICatQueryProcessor)ActivatorUtilities.CreateInstance(provider, descriptor.ImplementationType!);
    }
}
