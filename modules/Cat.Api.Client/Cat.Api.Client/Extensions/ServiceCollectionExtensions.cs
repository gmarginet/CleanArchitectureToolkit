using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Api.Client.Extensions;

/// <summary>
/// Registers the generated clients of other services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers a generated client with its own <see cref="System.Net.Http.HttpClient"/>, pointed at the API gateway.
    /// The address can be a plain address from configuration, or an address that service discovery resolves,
    /// such as <c>https+http://gateway</c>. The module does not reference service discovery or Aspire.
    /// </summary>
    /// <typeparam name="TClient">The interface of the client.</typeparam>
    /// <typeparam name="TImplementation">The generated client class. It takes an <see cref="System.Net.Http.HttpClient"/> in its constructor.</typeparam>
    /// <param name="services">The service collection to add the client to.</param>
    /// <param name="gatewayAddress">The address of the API gateway.</param>
    /// <returns>The builder of the <see cref="System.Net.Http.HttpClient"/>, to add handlers such as retries.</returns>
    public static IHttpClientBuilder AddCatApiClient<TClient, TImplementation>(this IServiceCollection services, string gatewayAddress)
        where TClient : class
        where TImplementation : class, TClient
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (string.IsNullOrWhiteSpace(gatewayAddress)) throw new ArgumentException("The address of the gateway is missing.", nameof(gatewayAddress));

        return services.AddHttpClient<TClient, TImplementation>(client => client.BaseAddress = new Uri(gatewayAddress));
    }
}
