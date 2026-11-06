using Cat.Api.Client.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Api.Client.Tests;

[TestFixture]
public class ServiceCollectionExtensionsTests
{
    public interface ISampleClient
    {
        HttpClient Http { get; }
    }

    public class SampleClient(HttpClient http) : ISampleClient
    {
        public HttpClient Http { get; } = http;
    }

    [Test]
    public void TheClient_GetsTheAddressOfTheGateway()
    {
        var services = new ServiceCollection();
        services.AddCatApiClient<ISampleClient, SampleClient>("http://localhost:5100");

        using var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<ISampleClient>();

        Assert.That(client.Http.BaseAddress, Is.EqualTo(new Uri("http://localhost:5100")));
    }

    [Test]
    public void AnAddressForServiceDiscovery_IsAccepted()
    {
        var services = new ServiceCollection();
        services.AddCatApiClient<ISampleClient, SampleClient>("https+http://gateway");

        using var provider = services.BuildServiceProvider();

        Assert.That(provider.GetRequiredService<ISampleClient>().Http.BaseAddress!.Host, Is.EqualTo("gateway"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public void AMissingAddress_IsRefused(string? address)
    {
        Assert.Throws<ArgumentException>(() => new ServiceCollection().AddCatApiClient<ISampleClient, SampleClient>(address!));
    }
}
