using Cat.Demo.CatalogService.Infrastructure.DataAccess;
using Cat.Localizations.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.CatalogService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the catalog database context for the given SQL Server connection string.
    /// </summary>
    public static IServiceCollection AddCatDemoCatalogDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddHealthChecks().AddDbContextCheck<CatalogDbContext>();
        services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));
        services.AddCatLocalizations<CatalogDbContext>();
        return services;
    }
}
