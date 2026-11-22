using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>Registers the database context of the service and its health check.</summary>
    public static IServiceCollection AddServiceShortDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddDbContextCheck<ServiceShortDbContext>();
#if (SqlServer)
        services.AddDbContext<ServiceShortDbContext>(options => options.UseSqlServer(connectionString));
#else
        services.AddDbContext<ServiceShortDbContext>(options => options.UseNpgsql(connectionString));
#endif
        return services;
    }

    /// <summary>
    /// Creates the database in development. It applies the migrations when the service has some,
    /// and creates the tables from the model when it has none yet.
    /// </summary>
    public static async Task InitializeServiceShortDatabaseAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ServiceShortDbContext>();

        if (dbContext.Database.GetMigrations().Any())
        {
            await dbContext.Database.MigrateAsync(cancellationToken);
        }
        else
        {
            await dbContext.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
