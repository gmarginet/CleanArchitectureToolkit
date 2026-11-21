using System.Net;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.Infrastructure.Extensions;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.Tests;

[TestFixture]
public class PaymentProviderResilienceTests
{
    private sealed class RecordingHandler(params HttpStatusCode[] answers) : HttpMessageHandler
    {
        public List<string?> Keys { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var key = request.Headers.TryGetValues("Idempotency-Key", out var values) ? values.Single() : null;
            Keys.Add(key);
            var status = answers[Math.Min(Keys.Count, answers.Length) - 1];
            var response = new HttpResponseMessage(status);
            if (status == HttpStatusCode.OK)
            {
                response.Content = new StringContent("""{"status":"approved","reference":"PAY-1"}""", System.Text.Encoding.UTF8, "application/json");
            }

            return Task.FromResult(response);
        }
    }

    private static ServiceProvider Build(RecordingHandler handler)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        // The default of AddServiceDefaults in the ServiceDefaults project.
        services.ConfigureHttpClientDefaults(http => http.AddCatResilience(CatResilienceProfile.Internal));
        services.AddCatDemoOrderPaymentProvider(new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["PaymentProvider:Url"] = "http://localhost:5103",
                ["PaymentProvider:ApiKey"] = "test"
            })
            .Build());
        services.AddHttpClient("IPaymentProviderClient").ConfigurePrimaryHttpMessageHandler(() => handler);
        return services.BuildServiceProvider();
    }

    [Test]
    public async Task AProviderThatFailsOnce_IsAskedAgainWithTheSameKeyAndTheChargeGoesThrough()
    {
        var handler = new RecordingHandler(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
        await using var provider = Build(handler);
        using var scope = provider.CreateScope();

        var result = await scope.ServiceProvider.GetRequiredService<IPaymentProvider>()
            .ChargeAsync("saga-1", "20261121-0001", 10m);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Approved, Is.True);
            Assert.That(result.Unavailable, Is.False);
            Assert.That(handler.Keys, Is.EqualTo(new[] { "saga-1", "saga-1" }));
        }
    }

    [Test]
    public async Task AProviderThatIsDown_IsTriedThreeTimesAndThenUnavailable()
    {
        var handler = new RecordingHandler(HttpStatusCode.ServiceUnavailable);
        await using var provider = Build(handler);
        using var scope = provider.CreateScope();

        var result = await scope.ServiceProvider.GetRequiredService<IPaymentProvider>()
            .ChargeAsync("saga-2", "20261121-0002", 10m);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Unavailable, Is.True);
            Assert.That(handler.Keys, Has.Count.EqualTo(3), "One try and the two retries of the External profile.");
        }
    }
}
