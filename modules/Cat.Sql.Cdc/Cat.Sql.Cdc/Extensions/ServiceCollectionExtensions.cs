using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cat.Sql.Cdc.Extensions;

/// <summary>
/// Registration helpers for the SQL Server change data capture module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the reader as a hosted service. It reads the tables you add and hands every change to the registered
    /// <see cref="Abstractions.ICatChangeSink"/>. Register a sink too, such as the one of <c>Cat.Sql.Cdc.Messaging</c>.
    /// The module never enables change data capture. Do that yourself with <c>sys.sp_cdc_enable_table</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configuration">Gives the settings from the section <c>CatSqlCdc</c>, see <see cref="CatCdcSettings"/>.</param>
    /// <param name="declare">Adds the tables to capture.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddCatSqlCdc(this IServiceCollection services, IConfiguration configuration, Action<CatCdcBuilder> declare)
    {
        var settings = new CatCdcSettings();
        configuration.GetSection(CatCdcSettings.ConfigurationSectionName).Bind(settings);

        var builder = new CatCdcBuilder();
        declare(builder);

        if (settings.BatchSize < 1)
        {
            throw new InvalidOperationException("The batch size must be at least 1.");
        }

        services.AddSingleton(settings);
        services.AddSingleton(builder.Tables);
        services.AddSingleton<CatCdcStatus>();
        services.TryAddSingleton<ICatCdcDatabase, SqlServerCdcDatabase>();
        services.AddHostedService<CatCdcService>();

        return services;
    }

    /// <summary>
    /// Adds a health check that is unhealthy when a table stopped reading, and degraded when the last poll of a table failed.
    /// </summary>
    /// <param name="builder">The health checks builder.</param>
    /// <param name="name">The name of the check. The default is <c>cat-sql-cdc</c>.</param>
    /// <returns>The health checks builder.</returns>
    public static IHealthChecksBuilder AddCatSqlCdcHealthCheck(this IHealthChecksBuilder builder, string name = "cat-sql-cdc")
    {
        return builder.AddCheck<CatCdcHealthCheck>(name);
    }
}
