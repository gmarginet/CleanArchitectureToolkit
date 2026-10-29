using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable RedundantBoolCompare

namespace Cat.ServiceCollection.Extensions;

/// <summary>
/// Extension methods for inspecting an <see cref="IServiceCollection"/>'s existing registrations.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Checks whether <typeparamref name="TService"/> is already registered in the service collection.
    /// </summary>
    /// <typeparam name="TService">The service type to look for.</typeparam>
    /// <param name="services">The service collection to check.</param>
    /// <returns><c>true</c> if a registration for <typeparamref name="TService"/> exists.</returns>
    public static bool HasRegistrationFor<TService>(this IServiceCollection services)
    {
        return services.HasRegistrationFor(typeof(TService));
    }

    /// <summary>
    /// Checks whether the given service type is already registered in the service collection. An open generic type
    /// (such as <c>typeof(IRepository&lt;&gt;)</c>) matches any registration for that generic definition.
    /// </summary>
    /// <param name="services">The service collection to check.</param>
    /// <param name="serviceType">The service type to look for.</param>
    /// <returns><c>true</c> if a matching registration exists.</returns>
    public static bool HasRegistrationFor(this IServiceCollection services, Type serviceType)
    {
        return serviceType.IsGenericTypeDefinition is true
            ? services.Any(x => x.ServiceType.IsGenericType && x.ServiceType.GetGenericTypeDefinition() == serviceType)
            : services.Any(x => x.ServiceType == serviceType);
    }
}