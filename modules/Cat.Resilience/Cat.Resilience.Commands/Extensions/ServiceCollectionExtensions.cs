using System;
using System.Linq;
using Cat.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Cat.Resilience.Abstractions;

namespace Cat.Resilience.Commands.Extensions;

/// <summary>
/// Registration helpers for the retry around the command processor.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Retries the command types that you list, through a resilience profile, with a fresh scope for every try.
    /// Register the commands module with <c>AddCatCommandsModule</c> and the resilience module with <c>AddCatResilienceModule</c> first,
    /// because the processor is wrapped and the pipelines come from there. <c>ICatCurrentScopeCommandProcessor</c> is not wrapped,
    /// because it runs in the current scope on purpose.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Lists the command types, for example <c>options.Retry&lt;PlaceOrderCommand&gt;()</c>.</param>
    /// <returns>The same service collection, for chaining.</returns>
    /// <exception cref="InvalidOperationException">A command type is listed, but no <c>ICatCommandProcessor</c> is registered yet.</exception>
    public static IServiceCollection AddCatCommandRetry(this IServiceCollection services, Action<CatCommandRetryOptions> configure)
    {
        var options = new CatCommandRetryOptions();
        configure(options);

        var descriptor = services.LastOrDefault(registration => registration.ServiceType == typeof(ICatCommandProcessor) && !registration.IsKeyedService);
        if (descriptor == null)
        {
            if (options.HasRules)
            {
                throw new InvalidOperationException(
                    "A command type is listed for a retry, but no ICatCommandProcessor is registered. Call AddCatCommandsModule of Cat.Commands before AddCatCommandRetry.");
            }

            return services;
        }

        services.Remove(descriptor);
        services.Add(new ServiceDescriptor(typeof(ICatCommandProcessor),
            provider => new CatRetryCommandProcessor(CreateInner(provider, descriptor), provider.GetRequiredService<ICatResiliencePipelines>(), options),
            descriptor.Lifetime));
        return services;
    }

    private static ICatCommandProcessor CreateInner(IServiceProvider provider, ServiceDescriptor descriptor)
    {
        if (descriptor.ImplementationInstance != null)
        {
            return (ICatCommandProcessor)descriptor.ImplementationInstance;
        }

        if (descriptor.ImplementationFactory != null)
        {
            return (ICatCommandProcessor)descriptor.ImplementationFactory(provider);
        }

        return (ICatCommandProcessor)ActivatorUtilities.CreateInstance(provider, descriptor.ImplementationType!);
    }
}
