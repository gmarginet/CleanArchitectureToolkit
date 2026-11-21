using System;
using System.Net.Http.Headers;
using Cat.Api.Client.Extensions;
using Cat.Dapper.SqlServer.Extensions;
using Cat.Demo.CatalogService.Api.Client;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.InventoryService.Api.Client;
using Cat.Demo.OrderService.Infrastructure.ApiClients;
using Cat.Demo.OrderService.Infrastructure.Catalog;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Inventory;
using Cat.Demo.OrderService.Infrastructure.PaymentProvider;
using Cat.Demo.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.Telemetry.Extensions;

namespace Cat.Demo.OrderService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    private const string FastFailProfile = "FastFail";

    /// <summary>
    /// Registers the order database context for the given SQL Server connection string.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderDatabase(this IServiceCollection services, string connectionString)
    {
        services.TryAddSingleton(TimeProvider.System);
        services.AddHealthChecks().AddDbContextCheck<OrderDbContext>();
        services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(connectionString));

        // Dapper reads the order overview. EF Core stays for the writes and the other reads.
        services.AddCatDapperSqlServer(connectionString);
        return services;
    }

    /// <summary>
    /// Registers the price provider. <see cref="CatalogPriceProvider"/> asks Catalog for the prices
    /// through the gateway, with the generated client. The AppHost gives Orders the address of the <c>gateway</c>.
    /// Services never call each other directly.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderPriceProvider(this IServiceCollection services, IConfiguration configuration)
    {
        // The resilience handler of ServiceDefaults adds retries and a circuit breaker to this client.
        services.AddCatApiClient<ICatalogClient, CatalogClient>("https+http://gateway");
        services.AddScoped<IPriceProvider, CatalogPriceProvider>();
        return services;
    }

    /// <summary>
    /// Registers the stock reservation. <see cref="InventoryStockReservation"/> reserves the stock at the Inventory service
    /// through the gateway, with the generated client.
    /// The call forwards the token of the user, because the inventory route is not anonymous.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderStockReservation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddDemoClientCredentials(configuration);
        services.TryAddTransient<ForwardBearerTokenHandler>();
        services.AddCatApiClient<IInventoryClient, InventoryClient>("https+http://gateway")
            .AddHttpMessageHandler<ForwardBearerTokenHandler>()
            .UseFastFailResilience();
        services.AddScoped<IStockReservation, InventoryStockReservation>();
        return services;
    }

    /// <summary>
    /// Registers the outside payment provider. <see cref="PaymentProviderGateway"/> calls it with the generated client,
    /// straight from the infrastructure and not through the gateway, because the provider is an integration and not one of our services.
    /// The AppHost gives Orders the address and the API key as <c>PaymentProvider:Url</c> and <c>PaymentProvider:ApiKey</c>.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderPaymentProvider(this IServiceCollection services, IConfiguration configuration)
    {
        var url = configuration["PaymentProvider:Url"]
            ?? throw new InvalidOperationException("The setting PaymentProvider:Url is missing. Start the demo with the AppHost.");
        var apiKey = configuration["PaymentProvider:ApiKey"]
            ?? throw new InvalidOperationException("The setting PaymentProvider:ApiKey is missing. Start the demo with the AppHost.");

        // The External profile of Cat.Resilience: a provider outside our system gets a longer wait, a retry that honours Retry-After
        // and a retry of a POST only when it carries an Idempotency-Key header, which every call here does.
        services.AddHttpClient<IPaymentProviderClient, PaymentProviderClient>(client =>
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            })
            .AddCatResilience(CatResilienceProfile.External)
            // No trace header goes to the provider. The call is still a span in the trace of Orders.
            .AddCatTelemetryBoundary();
        services.AddScoped<IPaymentProvider, PaymentProviderGateway>();
        return services;
    }

    /// <summary>
    /// Puts the FastFail resilience profile on a client that a person waits for while an order is placed.
    /// With the Internal profile, a service that is down makes the order wait about 50 seconds, and the gateway gives up after 30.
    /// Here one retry is enough, because the calls are safe to repeat: the order number is the key. One try takes at most 5 seconds,
    /// and the whole call at most 12, so Orders answers well before the gateway does.
    /// The profile replaces the default pipeline of the ServiceDefaults, so the client has only this one.
    /// </summary>
    private static IHttpClientBuilder UseFastFailResilience(this IHttpClientBuilder clientBuilder)
    {
        clientBuilder.Services.AddCatResilienceModule(options => options.AddProfile(FastFailProfile, profile =>
        {
            profile.Retry.MaxRetryAttempts = 1;
            profile.Retry.Delay = TimeSpan.FromMilliseconds(500);
            profile.AttemptTimeout.Timeout = TimeSpan.FromSeconds(5);
            profile.TotalTimeout.Timeout = TimeSpan.FromSeconds(12);
        }));

        return clientBuilder.AddCatResilience(FastFailProfile);
    }
}