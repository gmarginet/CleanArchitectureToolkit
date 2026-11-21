using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Queries.Abstractions;

/// <summary>
/// Registers a wrapper around <see cref="ICatQueryProcessor"/>, such as a cache or a retry.
/// Wrappers from different modules go in the order of their number, see <see cref="CatQueryProcessorOrder"/>,
/// and not in the order of the registration lines.
/// </summary>
public static class CatQueryProcessorWrapperExtensions
{
    /// <summary>
    /// Wraps the registered <see cref="ICatQueryProcessor"/>.
    /// The first call replaces the registration of the processor with one that builds the processor and all the wrappers.
    /// Later calls add their wrapper to the same registration.
    /// A wrapper with a lower order is further out. Wrappers with the same order are kept in the order of the calls, and the last one is outside.
    /// </summary>
    /// <param name="services">The service collection to change.</param>
    /// <param name="order">The place of the wrapper, from the outside in. Use a number of <see cref="CatQueryProcessorOrder"/>.</param>
    /// <param name="wrap">Creates the wrapper. It gets the service provider of the scope and the processor it must wrap.</param>
    /// <param name="callName">The name of the registration call, such as <c>AddCatQueryRetry</c>. It is used in the message of the exception.</param>
    /// <returns>The same service collection, for chaining.</returns>
    /// <exception cref="InvalidOperationException">No <see cref="ICatQueryProcessor"/> is registered yet.</exception>
    public static IServiceCollection AddCatQueryProcessorWrapper(
        this IServiceCollection services,
        int order,
        Func<IServiceProvider, ICatQueryProcessor, ICatQueryProcessor> wrap,
        string callName)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (wrap == null)
        {
            throw new ArgumentNullException(nameof(wrap));
        }

        var registry = services
            .Where(registration => registration.ServiceType == typeof(CatQueryProcessorWrappers) && !registration.IsKeyedService)
            .Select(registration => registration.ImplementationInstance)
            .OfType<CatQueryProcessorWrappers>()
            .FirstOrDefault();

        if (registry == null)
        {
            var descriptor = services.LastOrDefault(registration => registration.ServiceType == typeof(ICatQueryProcessor) && !registration.IsKeyedService);
            if (descriptor == null)
            {
                throw new InvalidOperationException(
                    $"No ICatQueryProcessor is registered. Call AddCatQueriesModule of Cat.Queries before {callName}.");
            }

            registry = new CatQueryProcessorWrappers(descriptor);
            services.Remove(descriptor);
            services.AddSingleton(registry);
            services.Add(new ServiceDescriptor(typeof(ICatQueryProcessor), registry.Build, descriptor.Lifetime));
        }

        registry.Add(order, wrap);
        return services;
    }

    private sealed class CatQueryProcessorWrappers
    {
        private readonly ServiceDescriptor _core;
        private readonly List<(int Order, int Sequence, Func<IServiceProvider, ICatQueryProcessor, ICatQueryProcessor> Wrap)> _wrappers
            = new List<(int, int, Func<IServiceProvider, ICatQueryProcessor, ICatQueryProcessor>)>();

        public CatQueryProcessorWrappers(ServiceDescriptor core)
        {
            _core = core;
        }

        public void Add(int order, Func<IServiceProvider, ICatQueryProcessor, ICatQueryProcessor> wrap)
        {
            _wrappers.Add((order, _wrappers.Count, wrap));
        }

        public ICatQueryProcessor Build(IServiceProvider provider)
        {
            var processor = CreateCore(provider);

            // The innermost wrapper goes on first: the highest order, and for equal orders the earliest call.
            foreach (var wrapper in _wrappers.OrderByDescending(item => item.Order).ThenBy(item => item.Sequence))
            {
                processor = wrapper.Wrap(provider, processor);
            }

            return processor;
        }

        private ICatQueryProcessor CreateCore(IServiceProvider provider)
        {
            if (_core.ImplementationInstance != null)
            {
                return (ICatQueryProcessor)_core.ImplementationInstance;
            }

            if (_core.ImplementationFactory != null)
            {
                return (ICatQueryProcessor)_core.ImplementationFactory(provider);
            }

            return (ICatQueryProcessor)ActivatorUtilities.CreateInstance(provider, _core.ImplementationType!);
        }
    }
}
