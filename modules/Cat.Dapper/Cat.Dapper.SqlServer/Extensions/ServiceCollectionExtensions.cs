using Cat.Dapper.Abstractions;
using Cat.Dapper.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Dapper.SqlServer.Extensions;

/// <summary>
/// Registration helpers for Dapper on SQL Server.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the SQL Server connection factory as a singleton, with the connection string, and the scoped session of
    /// <see cref="Cat.Dapper.Extensions.ServiceCollectionExtensions.AddCatDapperModule"/>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="connectionString">The connection string of the database.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatDapperSqlServer(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<ICatDbConnectionFactory>(new SqlServerConnectionFactory(connectionString));
        return services.AddCatDapperModule();
    }
}
