using System;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Demo.OrderService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the order database context for the given SQL Server connection string.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderDatabase(this IServiceCollection services, string connectionString)
    {
        services.TryAddSingleton(TimeProvider.System);
        services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }

    /// <summary>
    /// Registers the fakes for the services Orders talks to: Catalog (prices), Inventory (stock) and the payment provider.
    /// The fake stock reservation is a singleton, because it remembers its reservations in memory.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderFakes(this IServiceCollection services)
    {
        services.AddSingleton<IPriceProvider, FakePriceProvider>();
        services.AddSingleton<IStockReservation, FakeStockReservation>();
        services.AddSingleton<IPaymentProvider, FakePaymentProvider>();
        return services;
    }
}
