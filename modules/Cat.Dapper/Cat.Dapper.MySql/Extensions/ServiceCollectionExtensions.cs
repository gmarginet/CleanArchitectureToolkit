using Cat.Dapper.Abstractions;
using Cat.Dapper.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Dapper.MySql.Extensions;

/// <summary>
/// Registration helpers for Dapper on MySQL.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the MySQL connection factory as a singleton, with the connection string, and the scoped session of
    /// <see cref="Cat.Dapper.Extensions.ServiceCollectionExtensions.AddCatDapperModule"/>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="connectionString">The connection string of the database.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatDapperMySql(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<ICatDbConnectionFactory>(new MySqlConnectionFactory(connectionString));
        return services.AddCatDapperModule();
    }
}
