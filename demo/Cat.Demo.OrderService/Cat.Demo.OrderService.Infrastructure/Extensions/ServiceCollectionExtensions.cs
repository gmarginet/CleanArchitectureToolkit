using System;
using Cat.Api.Client.Extensions;
using Cat.Demo.CatalogService.Api.Client;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.InventoryService.Api.Client;
using Cat.Demo.OrderService.Infrastructure.ApiClients;
using Cat.Demo.OrderService.Infrastructure.Catalog;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Fakes;
using Cat.Demo.OrderService.Infrastructure.Inventory;
using Cat.Demo.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http.Resilience;

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
    /// Registers the stock reservation. When the host gives Orders an address for the <c>gateway</c>,
    /// <see cref="InventoryStockReservation"/> reserves the stock at the Inventory service through the gateway, with the generated client.
    /// The call forwards the token of the user, because the inventory route is not anonymous.
    /// Without an address, <see cref="FakeStockReservation"/> answers. It is a singleton, because it remembers its reservations in memory.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderStockReservation(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetSection("services:gateway").Exists())
        {
            services.AddHttpContextAccessor();
            services.AddDemoClientCredentials(configuration);
            services.TryAddTransient<ForwardBearerTokenHandler>();
            services.AddCatApiClient<IInventoryClient, InventoryClient>("https+http://gateway")
                .AddHttpMessageHandler<ForwardBearerTokenHandler>()
                .UseFastFailResilience();
            services.AddScoped<IStockReservation, InventoryStockReservation>();
        }
        else
        {
            services.AddSingleton<IStockReservation, FakeStockReservation>();
        }

        return services;
    }

    /// <summary>
    /// Replaces the standard resilience handler of a client that a person waits for while an order is placed.
    /// With the defaults, a service that is down makes the order wait about 50 seconds, and the gateway gives up after 30.
    /// Here one retry is enough, because the calls are safe to repeat: the order number is the key. One try takes at most 5 seconds,
    /// and the whole call at most 12, so Orders answers well before the gateway does.
    /// The default handler of the ServiceDefaults is removed first, so the client has only this one.
    /// </summary>
    private static IHttpClientBuilder UseFastFailResilience(this IHttpClientBuilder clientBuilder)
    {
        // Marked experimental by Microsoft, but it is the supported way to drop the default handler.
#pragma warning disable EXTEXP0001
        clientBuilder.RemoveAllResilienceHandlers();
#pragma warning restore EXTEXP0001
        clientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.MaxRetryAttempts = 1;
            options.Retry.Delay = TimeSpan.FromMilliseconds(500);
            options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(5);
            options.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(12);
        });

        return clientBuilder;
    }
}