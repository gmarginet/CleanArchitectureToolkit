using System;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.Catalog;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Fakes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    /// Registers the price provider. When the host gives Orders an address for the <c>catalog</c> service
    /// (Aspire does, as <c>services:catalog:*</c>), <see cref="CatalogPriceProvider"/> asks Catalog for the prices.
    /// Without an address, <see cref="FakePriceProvider"/> answers, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderPriceProvider(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("services:catalog").Exists())
        {
            // The resilience handler of ServiceDefaults adds retries and a circuit breaker to this client.
            services.AddHttpClient<IPriceProvider, CatalogPriceProvider>(client => client.BaseAddress = new Uri("https+http://catalog"));
        }
        else
        {
            services.AddSingleton<IPriceProvider, FakePriceProvider>();
        }

        return services;
    }

    /// <summary>
    /// Registers the fakes for the services Orders talks to: Inventory (stock) and the payment provider.
    /// The fake stock reservation is a singleton, because it remembers its reservations in memory.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderFakes(this IServiceCollection services)
    {
        services.AddSingleton<IStockReservation, FakeStockReservation>();
        services.AddSingleton<IPaymentProvider, FakePaymentProvider>();
        return services;
    }
}
