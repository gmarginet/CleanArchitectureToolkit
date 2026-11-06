using System;
using Cat.Api.Client.Extensions;
using Cat.Demo.CatalogService.Api.Client;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.Catalog;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Fakes;
using Cat.Demo.OrderService.Infrastructure.PaymentServices;
using Cat.Demo.PaymentService.Api.Client;
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
    /// Registers the price provider. When the host gives Orders an address for the <c>gateway</c>
    /// (Aspire does, as <c>services:gateway:*</c>), <see cref="CatalogPriceProvider"/> asks Catalog for the prices
    /// through the gateway, with the generated client. Services never call each other directly.
    /// Without an address, <see cref="FakePriceProvider"/> answers, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderPriceProvider(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("services:gateway").Exists())
        {
            // The resilience handler of ServiceDefaults adds retries and a circuit breaker to this client.
            services.AddCatApiClient<ICatalogClient, CatalogClient>("https+http://gateway");
            services.AddScoped<IPriceProvider, CatalogPriceProvider>();
        }
        else
        {
            services.AddSingleton<IPriceProvider, FakePriceProvider>();
        }

        return services;
    }

    /// <summary>
    /// Registers the payment provider. When the host gives Orders an address for the <c>gateway</c>
    /// (Aspire does, as <c>services:gateway:*</c>), <see cref="PaymentServiceProvider"/> takes the payment at the payment service
    /// through the gateway, with the generated client. The call forwards the token of the user, because the payment route is not anonymous.
    /// Without an address, <see cref="FakePaymentProvider"/> answers, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderPaymentProvider(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("services:gateway").Exists())
        {
            // The resilience handler of ServiceDefaults adds retries, a timeout and a circuit breaker to this client.
            services.AddHttpContextAccessor();
            services.AddTransient<ForwardBearerTokenHandler>();
            services.AddCatApiClient<IPaymentClient, PaymentClient>("https+http://gateway")
                .AddHttpMessageHandler<ForwardBearerTokenHandler>();
            services.AddScoped<IPaymentProvider, PaymentServiceProvider>();
        }
        else
        {
            services.AddSingleton<IPaymentProvider, FakePaymentProvider>();
        }

        return services;
    }

    /// <summary>
    /// Registers the fake for the Inventory service (stock), which is not built yet.
    /// The fake stock reservation is a singleton, because it remembers its reservations in memory.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderFakes(this IServiceCollection services)
    {
        services.AddSingleton<IStockReservation, FakeStockReservation>();
        return services;
    }
}
