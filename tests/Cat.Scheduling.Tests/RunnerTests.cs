using System.Diagnostics;
using Cat.Responses;
using Cat.Scheduling.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class RunnerTests
{
    private ProcessorState _state = null!;
    private FakeTimeProvider _clock = null!;

    [SetUp]
    public void SetUp()
    {
        _state = new ProcessorState();
        _clock = TestHost.NewClock();
    }

    private ServiceProvider Build(Action<CatJobOptions>? configure = null, string? systemUser = null)
    {
        return TestHost.Build(_state, _clock, builder =>
        {
            if (systemUser != null)
            {
                builder.RunAs(systemUser);
            }

            builder.Job<PingRequest>("ping", "5 0 * * *", configure);
        });
    }

    [Test]
    public async Task RunAsync_SucceededResponse_Succeeds()
    {
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        Assert.That(result.ErrorCode, Is.Null);
        Assert.That(result.Attempts, Is.EqualTo(1));
        Assert.That(_state.Requests.Single(), Is.TypeOf<PingRequest>());
    }

    [Test]
    public async Task RunAsync_NameIsNotCaseSensitive()
    {
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("PING");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
    }

    [Test]
    public async Task RunAsync_UnknownJob_Throws()
    {
        using var provider = Build();

        await Assert.ThrowsAsync<ArgumentException>(() => provider.GetRequiredService<ICatJobRunner>().RunAsync("nope"));
    }

    [Test]
    public async Task RunAsync_FailedResponse_FailsWithTheFirstErrorCodeAndDoesNotRetry()
    {
        _state.Respond = (_, _) => Task.FromResult(CatResponse.BadRequest(CatError.Create("TST-001", "First"), CatError.Create("TST-002", "Second")));
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(result.ErrorCode, Is.EqualTo("TST-001"));
        Assert.That(result.Attempts, Is.EqualTo(1));
        Assert.That(_state.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task RunAsync_ExceptionInTheRequest_FailsWithTheExceptionTypeName()
    {
        _state.Respond = (_, _) => throw new InvalidOperationException("boom");
        using var provider = Build();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(result.ErrorCode, Is.EqualTo(nameof(InvalidOperationException)));
    }

    [Test]
    public async Task RunAsync_RunsAsTheSystemUser()
    {
        using var provider = Build(systemUser: "orders");

        await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        var user = _state.Users.Single();
        Assert.That(user.UserId, Is.EqualTo("orders"));
        Assert.That(user.IsAuthenticated, Is.True);
        Assert.That(user.IsInRole("system"), Is.True);
    }

    [Test]
    public async Task RunAsync_DefaultSystemUser_IsTheScheduler()
    {
        using var provider = Build();

        await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(_state.Users.Single().UserId, Is.EqualTo(CatSchedulerBuilder.DefaultSystemUserName));
    }

    [Test]
    public async Task RunAsync_FactoryOverload_SendsTheRequestOfTheFactory()
    {
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job("greet", "5 0 * * *", () => new GreetRequest("Ada")));

        await provider.GetRequiredService<ICatJobRunner>().RunAsync("greet");

        Assert.That(_state.Requests.Single(), Is.EqualTo(new GreetRequest("Ada")));
    }

    [Test]
    public async Task RunAsync_Retries_RunsAgainAfterTheDelayUntilItSucceeds()
    {
        _state.Respond = (attempt, _) => Task.FromResult(attempt < 3 ? CatResponse.BadRequest(CatError.Create("TST-001", "No")) : CatResponse.Ok());
        using var provider = Build(options =>
        {
            options.MaxRetries = 2;
            options.RetryDelay = TimeSpan.FromSeconds(10);
        });

        var run = provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");
        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(2), () => run.IsCompleted);
        var result = await run;

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        Assert.That(result.Attempts, Is.EqualTo(3));
        Assert.That(_clock.GetUtcNow() - TestHost.Start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(20)));
    }

    [Test]
    public async Task RunAsync_GrowingDelay_DoublesTheWaitWithEveryRetry()
    {
        _state.Respond = (attempt, _) => Task.FromResult(attempt < 3 ? CatResponse.BadRequest(CatError.Create("TST-001", "No")) : CatResponse.Ok());
        using var provider = Build(options =>
        {
            options.MaxRetries = 2;
            options.RetryDelay = TimeSpan.FromSeconds(10);
            options.GrowingRetryDelay = true;
        });

        var run = provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");
        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(2), () => run.IsCompleted);
        var result = await run;

        Assert.That(result.Attempts, Is.EqualTo(3));
        Assert.That(_clock.GetUtcNow() - TestHost.Start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public async Task RunAsync_RetriesRunOut_StaysFailed()
    {
        _state.Respond = (_, _) => Task.FromResult(CatResponse.BadRequest(CatError.Create("TST-001", "No")));
        using var provider = Build(options =>
        {
            options.MaxRetries = 2;
            options.RetryDelay = TimeSpan.FromSeconds(1);
        });

        var run = provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");
        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(1), () => run.IsCompleted);
        var result = await run;

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(result.Attempts, Is.EqualTo(3));
        Assert.That(_state.Calls, Is.EqualTo(3));
    }

    [Test]
    public async Task RunAsync_StartsAnActivityWithTheJobName()
    {
        var started = new List<Activity>();
        using var listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == CatSchedulingTelemetry.SourceName,
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
            ActivityStopped = activity => { lock (started) { started.Add(activity); } }
        };
        ActivitySource.AddActivityListener(listener);
        using var provider = Build();

        await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Activity[] seen;
        lock (started) { seen = started.ToArray(); }
        var activity = seen.Single(candidate => candidate.GetTagItem("cat.scheduling.job") as string == "ping");
        Assert.That(activity.OperationName, Is.EqualTo("Cat.Scheduling.Run ping"));
        Assert.That(activity.GetTagItem("cat.scheduling.attempts"), Is.EqualTo(1));
    }
}
