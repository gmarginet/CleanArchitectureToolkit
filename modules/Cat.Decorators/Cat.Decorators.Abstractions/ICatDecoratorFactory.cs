using System;

namespace Cat.Decorators.Abstractions;

/// <summary>
/// Gets a service wrapped in the decorators registered for it.
/// The service type must be a closed generic type, like <c>IHandler&lt;MyRequest&gt;</c>.
/// </summary>
public interface ICatDecoratorFactory
{
    /// <summary>
    /// Gets the decorated service, or throws when the service isn't registered.
    /// </summary>
    /// <typeparam name="TService">The closed generic service type.</typeparam>
    /// <param name="serviceProvider">Resolves the service and the dependencies of the decorators.</param>
    /// <returns>The service, wrapped in its decorators.</returns>
    /// <exception cref="InvalidOperationException">The service isn't registered.</exception>
    TService GetRequiredDecoratedService<TService>(IServiceProvider serviceProvider);

    /// <summary>
    /// Gets the decorated service, or throws when the service isn't registered.
    /// </summary>
    /// <param name="serviceProvider">Resolves the service and the dependencies of the decorators.</param>
    /// <param name="serviceType">The closed generic service type.</param>
    /// <returns>The service, wrapped in its decorators.</returns>
    /// <exception cref="InvalidOperationException">The service isn't registered.</exception>
    object GetRequiredDecoratedService(IServiceProvider serviceProvider, Type serviceType);

    /// <summary>
    /// Gets the decorated service, or <c>null</c> when the service isn't registered.
    /// </summary>
    /// <typeparam name="TService">The closed generic service type.</typeparam>
    /// <param name="serviceProvider">Resolves the service and the dependencies of the decorators.</param>
    /// <returns>The service, wrapped in its decorators, or <c>null</c>.</returns>
    TService? GetDecoratedService<TService>(IServiceProvider serviceProvider);

    /// <summary>
    /// Gets the decorated service, or <c>null</c> when the service isn't registered.
    /// </summary>
    /// <param name="serviceProvider">Resolves the service and the dependencies of the decorators.</param>
    /// <param name="serviceType">The closed generic service type.</param>
    /// <returns>The service, wrapped in its decorators, or <c>null</c>.</returns>
    object? GetDecoratedService(IServiceProvider serviceProvider, Type serviceType);
}