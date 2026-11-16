using Cat.Dapper.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Dapper.Extensions;

/// <summary>
/// Registration helpers for the Dapper module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatDbSession"/> with a scoped lifetime, so every scope gets one connection
    /// and the connection is disposed with the scope. It needs an <see cref="ICatDbConnectionFactory"/>, which a database project
    /// registers, such as <c>AddCatDapperSqlServer</c> in <c>Cat.Dapper.SqlServer</c>.
    /// Handlers are not registered here. Register them with <c>AddCatQueriesModule</c> and <c>AddCatCommandsModule</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatDapperModule(this IServiceCollection services)
    {
        services.TryAddScoped<ICatDbSession, CatDbSession>();
        return services;
    }
}
