using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.InventoryService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the inventory database context for the given SQL Server connection string.
    /// The database and its schema exist already. Inventory never creates them.
    /// </summary>
    public static IServiceCollection AddCatDemoInventoryDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
