using Cat.Resilience.Abstractions;
using Cat.Resilience.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Scheduling.Abstractions;
using Cat.Scheduling.Resilience;
using Cat.Scheduling.Resilience.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class ResilienceBridgeTests
{
    private ProcessorState _state = null!;
    private FakeTimeProvider _clock = null!;

    [SetUp]
    public void SetUp()
    {
        _state = new ProcessorState();
        _clock = TestHost.NewClock();
    }

    private ServiceProvider Build(Action<CatSchedulingResilienceOptions>? configure = null)
    {
        return TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), more: services =>
        {
            services.AddCatResilienceModule(options =>
            {
                // No waiting between tries, so the test does not need the fake clock.
                foreach (var profile in options.Profiles.Values)
                {
                    profile.Retry.Delay = TimeSpan.Zero;
                    profile.Retry.UseJitter = false;
                    profile.Retry.BackoffType = CatBackoffType.Constant;
                }

                options.AddProfile("NoRetry", profile => profile.Retry.MaxRetryAttempts = 0);
            });
            services.AddCatSchedulingResilience(configure);
        });
    }

    private static ICatResponse ServerError() => CatResponse.InternalServerError(CatError.Create("TST-500", "Boom"));

    [Test]
    public async Task RunAsync_InternalServerError_IsRetriedUntilItSucceeds()
    {
        _state.Respond = (attempt, _) => Task.FromResult(attempt < 3 ? ServerError() : CatResponse.Ok());
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        Assert.That(result.Attempts, Is.EqualTo(3));
    }

    [Test]
    public async Task RunAsync_Exception_IsRetried()
    {
        _state.Respond = (attempt, _) => attempt < 2 ? throw new InvalidOperationException("glitch") : Task.FromResult(CatResponse.Ok());
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        Assert.That(result.Attempts, Is.EqualTo(2));
    }

    [Test]
    public async Task RunAsync_BadRequest_IsNeverRetried()
    {
        _state.Respond = (_, _) => Task.FromResult(CatResponse.BadRequest(CatError.Create("TST-001", "No")));
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(result.ErrorCode, Is.EqualTo("TST-001"));
        Assert.That(result.Attempts, Is.EqualTo(1));
    }

    [Test]
    public async Task RunAsync_RetriesRunOut_FailsWithTheLastErrorCode()
    {
        _state.Respond = (_, _) => Task.FromResult(ServerError());
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(result.ErrorCode, Is.EqualTo("TST-500"));
        Assert.That(result.Attempts, Is.EqualTo(4), "One try and three retries of the Internal profile.");
    }

    [Test]
    public async Task RunAsync_ProfileOfTheJob_DecidesTheRetries()
    {
        _state.Respond = (_, _) => Task.FromResult(ServerError());
        using var provider = Build(options => options.JobProfiles["ping"] = "NoRetry");

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Attempts, Is.EqualTo(1));
    }

    [Test]
    public async Task RunAsync_EveryTryRunsAsTheSystemUser()
    {
        _state.Respond = (attempt, _) => Task.FromResult(attempt < 2 ? ServerError() : CatResponse.Ok());
        using var provider = Build();

        await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(_state.Users.Select(user => user.UserId), Is.All.EqualTo(CatSchedulerBuilder.DefaultSystemUserName));
        Assert.That(_state.Users, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task RunAsync_WithoutTheBridge_RunsOnceAfterAServerError()
    {
        _state.Respond = (_, _) => Task.FromResult(ServerError());
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"));

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Attempts, Is.EqualTo(1));
    }
}
