using Cat.Expressions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Expressions.Extensions;

/// <summary>
/// Registers the Cat Expressions module's compiled member expression cache in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatCompiledMemberExpressionCache{T}"/> as a singleton, backed by the caching implementation.
    /// </summary>
    /// <param name="services">The service collection to add the registration to.</param>
    public static void AddCatCompiledMemberExpressionCache(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ICatCompiledMemberExpressionCache<>), typeof(CatCompiledMemberExpressionCache<>));
    }

    /// <summary>
    /// Registers <see cref="ICatCompiledMemberExpressionCache{T}"/> as a singleton, backed by the non-caching implementation.
    /// </summary>
    /// <param name="services">The service collection to add the registration to.</param>
    public static void AddCatNoCacheCompiledMemberExpressionCache(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ICatCompiledMemberExpressionCache<>), typeof(CatNoCacheCompiledMemberExpressionCache<>));
    }
}