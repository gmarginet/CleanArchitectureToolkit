using System.Net;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Options;

namespace Cat.Resilience.Tests;

[TestFixture]
public class ResilienceTests
{
    private static void FastRetries(CatResilienceOptions options)
    {
        foreach (var profile in options.Profiles.Values)
        {
            profile.Retry.Delay = TimeSpan.Zero;
            profile.Retry.UseJitter = false;
            profile.Retry.BackoffType = CatBackoffType.Constant;
        }
    }

    private static (ServiceProvider Provider, StubHandler Handler) Build(string profile, Action<IServiceCollection>? arrange = null,
        params HttpStatusCode[] statusCodes)
    {
        var handler = new StubHandler(statusCodes);
        var services = new ServiceCollection();
        services.AddCatResilienceModule(FastRetries);
        arrange?.Invoke(services);
        services.AddHttpClient("test", c => c.BaseAddress = new Uri("http://localhost"))
            .ConfigurePrimaryHttpMessageHandler(() => handler)
            .AddCatResilience(profile);
        return (services.BuildServiceProvider(), handler);
    }

    private static HttpClient Client(ServiceProvider provider) =>
        provider.GetRequiredService<IHttpClientFactory>().CreateClient("test");

    [Test]
    public async Task Internal_profile_retries_a_get_that_fails_once()
    {
        var (provider, handler) = Build(CatResilienceProfile.Internal, null,
            HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);

        var response = await Client(provider).GetAsync("/x");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(handler.Calls, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task External_profile_does_not_retry_a_post_without_an_idempotency_key()
    {
        var (provider, handler) = Build(CatResilienceProfile.External, null,
            HttpStatusCode.InternalServerError, HttpStatusCode.OK);

        var response = await Client(provider).PostAsync("/pay", new StringContent("{}"));

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(handler.Calls, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task External_profile_retries_a_post_with_an_idempotency_key()
    {
        var (provider, handler) = Build(CatResilienceProfile.External, null,
            HttpStatusCode.InternalServerError, HttpStatusCode.OK);
        var request = new HttpRequestMessage(HttpMethod.Post, "/pay") { Content = new StringContent("{}") };
        request.Headers.Add("Idempotency-Key", "saga-1");

        var response = await Client(provider).SendAsync(request);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(handler.Calls, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task External_profile_replaces_the_default_pipeline_of_the_client()
    {
        var handler = new StubHandler(HttpStatusCode.InternalServerError, HttpStatusCode.OK);
        var services = new ServiceCollection();
        services.AddCatResilienceModule(FastRetries);
        // The default adds the standard handler to every client, as ServiceDefaults of the demo does.
        services.ConfigureHttpClientDefaults(http => http.AddStandardResilienceHandler());
        services.AddHttpClient("test", c => c.BaseAddress = new Uri("http://localhost"))
            .ConfigurePrimaryHttpMessageHandler(() => handler)
            .AddCatResilience(CatResilienceProfile.External);
        await using var provider = services.BuildServiceProvider();

        await provider.GetRequiredService<IHttpClientFactory>().CreateClient("test")
            .PostAsync("/pay", new StringContent("{}"));

        // The standard handler would have retried the POST. Only the external profile is left.
        Assert.That(handler.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task A_profile_that_does_not_exist_fails_the_startup()
    {
        var (provider, _) = Build("Nope");

        var validator = provider.GetServices<IHostedService>().Single();

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => validator.StartAsync(CancellationToken.None));
        Assert.That(exception!.Message, Does.Contain("Nope"));
        await provider.DisposeAsync();
    }

    [Test]
    public async Task Configuration_wins_over_code_and_adds_profiles()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Cat:Resilience:Profiles:FastFail:Retry:MaxRetryAttempts"] = "0",
                ["Cat:Resilience:Profiles:Internal:Retry:MaxRetryAttempts"] = "7"
            })
            .Build();
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddCatResilienceModule(o => o.AddProfile(CatResilienceProfile.Internal, p => p.Retry.MaxRetryAttempts = 5));
        await using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<IOptions<CatResilienceOptions>>().Value;

        Assert.Multiple(() =>
        {
            Assert.That(options.Profiles[CatResilienceProfile.Internal].Retry.MaxRetryAttempts, Is.EqualTo(7));
            Assert.That(options.Profiles["FastFail"].Retry.MaxRetryAttempts, Is.EqualTo(0));
        });
    }

    [Test]
    public async Task A_pipeline_for_one_call_retries_an_exception()
    {
        var services = new ServiceCollection();
        services.AddCatResilienceModule(FastRetries);
        await using var provider = services.BuildServiceProvider();
        var attempts = 0;

        var result = await provider.GetRequiredService<ICatResiliencePipelines>()
            .Get(CatResilienceProfile.Internal)
            .ExecuteAsync(_ =>
            {
                attempts++;
                return attempts < 3 ? throw new IOException("glitch") : Task.FromResult("done");
            });

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo("done"));
            Assert.That(attempts, Is.EqualTo(3));
        });
    }

    private sealed class StubHandler(params HttpStatusCode[] statusCodes) : HttpMessageHandler
    {
        private readonly Queue<HttpStatusCode> _statusCodes = new(statusCodes);

        public int Calls { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Calls++;
            var status = _statusCodes.Count > 0 ? _statusCodes.Dequeue() : HttpStatusCode.OK;
            return Task.FromResult(new HttpResponseMessage(status) { RequestMessage = request });
        }
    }
}
