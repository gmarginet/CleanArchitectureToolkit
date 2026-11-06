using System.Net;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class FastFailResilienceTests
{
    private sealed class CountingHandler : HttpMessageHandler
    {
        public int Calls;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref Calls);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadGateway));
        }
    }

    [Test]
    public async Task AStockCallToADownService_ShouldTryTwiceAndThenGiveUp()
    {
        var handler = new CountingHandler();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddHttpContextAccessor();
        // The default of AddServiceDefaults in the ServiceDefaults project.
        services.ConfigureHttpClientDefaults(http => http.AddStandardResilienceHandler());
        services.AddCatDemoOrderStockReservation(new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?> { ["services:gateway:http:0"] = "http://localhost:5100" })
            .Build());
        services.AddHttpClient("IInventoryClient").ConfigurePrimaryHttpMessageHandler(() => handler);
        await using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        var result = await scope.ServiceProvider.GetRequiredService<IStockReservation>()
            .ReserveAsync("20261106-0001", [new StockReservationLine(Guid.NewGuid(), "9780141036144", 1)]);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Unavailable, Is.True);
            Assert.That(handler.Calls, Is.EqualTo(2), "One try and one retry. The default is four tries.");
        }
    }
}
